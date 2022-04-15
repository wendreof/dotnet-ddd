using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {

    [AllowAnonymous]
    [HttpPost]
    public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService loginService)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (loginDto == null)
      {
        return BadRequest();
      }

      try
      {
        var result = await loginService.FindByLogin(loginDto);
        if (result != null)
        {
          return Ok(result);
        }
        else
        {
          return NotFound();
        }
      }
      catch (ArgumentException ex)
      {
        return StatusCode(500, ex.Message);
      }

    }
  }
}