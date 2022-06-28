using Health;
using Microsoft.AspNetCore.Mvc;

[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHealthDb(builder.Configuration.GetValue<string>("DataSources:DB:connectionString"));
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddHealthServices();

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

