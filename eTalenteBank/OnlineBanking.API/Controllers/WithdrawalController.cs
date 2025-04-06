using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Shared.Dto;

namespace OnlineBanking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WithdrawalController : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> Withdraw([FromBody] WithdrawalDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        return Ok();
    }
}