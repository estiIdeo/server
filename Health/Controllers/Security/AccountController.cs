using Health.Core.Framework.Account.Authentication;
using Health.Core.Framework.Account.Users;
using Health.Core.Interfaces.Services;
using Health.Core.Interfaces.Services.Security;
using Health.Core.Types.Exceptions;
using Health.Web.Extensions.Common;
using Ideo.NetCore.Web.Security.Authentication.RefreshToken.Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace Health.Controllers.Security
{
    [Route("~/api/[controller]")]
    public class AccountController : HealthApiController
    {
        #region Fields
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IPermissionsService _permissionsService;
        #endregion

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, IPermissionsService permissionsService)
        {
            this._logger = logger;
            this._accountService = accountService;
            this._permissionsService = permissionsService;
        }

        /// <summary>
        ///     Authenticate user, Login and get a JWT token.
        /// </summary>
        /// <param name="request">Model to Authenticate user credentials</param>
        /// <returns>Returns Bearer JWT token</returns>
        /// <response code="200">Returned if authentication was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResponseLogicModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestLogicModel request, [FromQuery] string otp = null)
        {
            try
            {
                var result = !string.IsNullOrEmpty(otp) ?
                    await _accountService.Validate(request, otp) :
                    await _accountService.Validate(request);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new { Message = "User not found or invalid username and password." });

            }
            catch (Exception ex)
            {
                ex.Data.Add("Request", request);
                ex.Data.Add("HResult", ex.HResult);
                _logger.LogError(ex, $"{this.GetType().Name} | Authenticate failed");
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred, please call support. (Error: {ex.HResult})");
            }
        }

        /// <summary>
        ///     Register a new user
        /// </summary>
        /// <param name="request">Model to create a new user</param>
        /// <returns>Returns the created User</returns>
        /// <response code="201">Returned if user creation was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed (Invalid credentials)</response>
        /// <response code="409">Returned when User already exists</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserLogicModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationLogicModel request)
        {
            try
            {
                //var response = await _accountService.RegisterUser(request);
                //if (response != null)
                //{
                //    return Created(this.Url.Link("", new { Controller = "Users", Action = "GetById", id = response.Id }), response);
                //}

                return NotFound("Invalid credentials, please try again.");
            }
            catch (AlreadyExistsException ex)
            {
                ex.Data.Add("Request", request);
                ex.Data.Add("HResult", ex.HResult);
                _logger.LogError(ex, $"{this.GetType().Name} | Register failed");
                return Conflict(new { Message = "User already exists." });

            }
            catch (Exception ex)
            {
                ex.Data.Add("Request", request);
                ex.Data.Add("HResult", ex.HResult);
                _logger.LogError(ex, $"{this.GetType().Name} | Register failed");
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred, please call support. (Error: {ex.HResult})");
            }
        }

        /// <summary>
        ///     Action to Get current user permissions.
        /// </summary>
        /// <returns>Returns user permissions.</returns>
        /// <response code="200">Returned when request initiated successfully</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Permissions")]
        [Authorize]
        public async Task<ActionResult<Dictionary<string, IEnumerable<string>>>> GetPermissions()
        {
            try
            {
                var response = await _permissionsService.Get();
                return Ok(response);
            }
            catch (Exception ex)
            {
                ex.Data.Add("HResult", ex.HResult);
                _logger.LogError(ex, $"{this.GetType().Name} | GetPermissions failed");
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred. (Error: {ex.HResult})");
            }
        }

        /// <summary>
        ///     Action to refresh a token.
        /// </summary>
        /// <param name="model">Model to Authenticate user credentials</param>
        /// <returns>Returns Bearer JWT token</returns>
        /// <response code="200">Returned if authentication was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestLogicModel model)
        {
            try
            {
                var result = await _accountService.Refresh(model);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound("Invalid credentials, please try again.");
            }
            catch (SecurityTokenException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Send a ResetPasswordLink to client email.
        /// </summary>
        /// <param name="email">The customer email.</param>
        /// <returns>Email sent indication</returns>
        /// <response code="200">Returned if authentication was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("SendPasswordResetEmail/{email}")]
        public async Task<IActionResult> SendPasswordResetEmail([FromRoute] string email)
        {

            var result = await _accountService.SendPasswordResetEmail(email);
            if (result)
            {
                return Ok();
            }
            return NotFound(new { Message = "User not found or invalid username and password." });

        }

        /// <summary>
        ///     Send a ResetPasswordLink to client phone.
        /// </summary>
        /// <param name="phone">The customer phone.</param>
        /// <returns>Email sent indication</returns>
        /// <response code="200">Returned if authentication was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("SendPasswordResetPhone/{phone}")]
        public async Task<IActionResult> SendPasswordResetPhone([FromRoute] string phone)
        {

            var result = await _accountService.SendPasswordResetEmail(phone: phone);
            if (result)
            {
                return Ok();
            }
            return NotFound(new { Message = "User not found or invalid username and password." });

        }

        /// <summary>
        ///     Send a ResetPasswordLink to client phone.
        /// </summary>
        /// <param name="hash">The customer hashed username.</param>
        /// <returns>Email sent indication</returns>
        /// <response code="200">Returned if authentication was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("RessetPassword/Translate")]
        public async Task<IActionResult> TranslateHashedUsername([FromQuery] string hash)
        {

            var result = _accountService.TranslateHashedUsername(hash);
            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            return NotFound(new { Message = "User not found or invalid username and password." });

        }


        /// <summary>
        ///     Change user password by reset token (via email).
        /// </summary>
        /// <param name="email">The customer email.</param>
        /// <returns>Email sent indication</returns>
        /// <response code="200">Returned if authentication was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("ChangePasswordByToken")]
        public async Task<IActionResult> ChangePasswordByToken([FromBody] ForgotPasswordLogicModel request, [FromQuery] string otp = null)
        {
            try
            {
                var result = await _accountService.VerifyResetToken(request, otp);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new { Message = "User not found or invalid username and password." });

            }
            catch (Exception ex)
            {
                //ex.Data.Add("Request", request);
                ex.Data.Add("HResult", ex.HResult);
                _logger.LogError(ex, $"{this.GetType().Name} | ChangePasswordByToken failed");
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred, please call support. (Error: {ex.HResult})");
            }
        }
    }
}
