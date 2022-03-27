using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult> GetAll([FromServices] IUserService service)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        return Ok(await service.GetAll());
      }
      catch (ArgumentException ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

  }
}