using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.API.Model;
using OnlineBanking.Application.Interfaces;

namespace OnlineBanking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost(Name = "Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        
        var token = await _authenticationService.GenerateJwtToken(model.Email, model.Password);

        if (string.IsNullOrEmpty(token))
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        return Ok(new { token = token});
    }

}