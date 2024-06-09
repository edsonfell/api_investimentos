using app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xp_project.Models;
using xp_project.ViewModels;

namespace xp_project.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsuariosAsync([FromServices] AppDbContext context)
        {
            var usuario = await context
                .Usuarios
                .AsNoTracking()
                .ToListAsync();
            return Ok(usuario);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUsuarioByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] Guid id)
        {
            var usuario = await context
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return usuario == null ? NotFound() : Ok(usuario);
        }
    }
}
