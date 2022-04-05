using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {

    [HttpPost]
    public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService loginService)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (userEntity == null)
      {
        return BadRequest();
      }

      try
      {
        var result = await loginService.FindByLogin(userEntity);
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