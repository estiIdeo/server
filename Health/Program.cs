using Health;
using Health.Core.Domain.Identity;
using Health.Core.Types.Application;
using Health.Data;
using Health.DataAccessLayer;
using Ideo.NetCore.Data.Encryption.AES.Configuration;
using Ideo.NetCore.Data.Encryption.Core.Interfaces;
using Ideo.NetCore.Framework.Mail.Smtp.Core.Models;
using Ideo.NetCore.Framework.Sms.InforUMobile;
using Ideo.NetCore.Framework.Sms.InforUMobile.Core.Configuration;
using Ideo.NetCore.Web.Security.Authentication.Core.Models;
using Ideo.NetCore.Web.Security.TwoFA.OTP;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdeoRefreshToken<HealthDbContext, long>();
builder.Services.AddIdeoQueryBuilder();
builder.Services.UseIdeoAuthentication(builder.Configuration.GetSection("Jwt").Get<JwtConfig>(), new JwtBearerEvents
{
    OnTokenValidated = context =>
    {
        var host = context.HttpContext.Request.Host.Value;
        return Task.CompletedTask;
    },
    OnMessageReceived = context =>
    {
        var accessToken = context.Request.Query["access_token"];

        if (!string.IsNullOrEmpty(accessToken))
        {
            context.Token = context.Request.Query["access_token"];
        }
        return Task.CompletedTask;
    }

});
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddRazorPages();
builder.Services.AddHealthDb(builder.Configuration.GetValue<string>("DataSources:DB:connectionString"));
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
        .AddEntityFrameworkStores<HealthDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddHealthServices();
builder.Services.AddHealthDataAccessLayer();
builder.Services.AddIdeoSmtp(builder.Configuration.GetSection("Smtp").Get<SmtpConfig>());
builder.Services.AddIdeoShamirSms(builder.Configuration.GetSection("Integrations:Sms:InforuMobile").Get<InforuMobile>());
var otpConfiguration = builder.Configuration.GetSection("Otp").Get<OtpConfiguration>();
builder.Services.AddIdeoOTP<HealthDbContext>(c =>
{
    c.MaxTicketDateValidityInMinutes = otpConfiguration.MaxTicketDateValidityInMinutes;
    c.OtpMessage = otpConfiguration.OtpMessage;
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            //.AllowAnyOrigin()
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .WithExposedHeaders("Content-Disposition");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();


app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();
app.Run();

