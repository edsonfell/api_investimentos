using app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xp_project.Models;
using xp_project.ViewModels;

namespace xp_project.Controllers
{

    [ApiController]
    [Route("v1/gestao-produto")]
    public class GestaoProdutoApiController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProdutoAsync([FromServices] AppDbContext context)
        {
            var produtos = await context
                .ProdutoFinanceiros
                .AsNoTracking()
                .ToListAsync();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProdutoByIdAsync(
            [FromServices] AppDbContext context, 
            [FromRoute] Guid id)
        {
            var produto = await context
                .ProdutoFinanceiros
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProdutoAsync(
            [FromServices] AppDbContext context,
            [FromBody] ProdutoFinanceiroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var produto = new ProdutoFinanceiro
            {
                Nome = model.Nome,
                Descricao = model.Descricao,
                ValorCota = model.ValorCota,
                Vencimento = model.Vencimento.ToUniversalTime(),
            };
            try
            {
                await context.ProdutoFinanceiros.AddAsync(produto);
                await context.SaveChangesAsync();
                return Created($"v1/gestao-produto/{produto.Id}", produto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutProdutoAsync(
            [FromServices] AppDbContext context,
            [FromBody] ProdutoFinanceiroViewModel model,
            [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = await context
                .ProdutoFinanceiros
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }
            
            try
            {
                produto.Nome = model.Nome;
                produto.Descricao = model.Descricao;
                produto.ValorCota = model.ValorCota;
                produto.Vencimento = model.Vencimento.ToUniversalTime();

                context.ProdutoFinanceiros.Update(produto);
                await context.SaveChangesAsync();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProdutosAsyncById(
            [FromServices] AppDbContext context,
            [FromRoute] Guid id)
        {
            try
            {
                var produto = await context
                .ProdutoFinanceiros
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

                if (produto == null)
                {
                    return NotFound();
                }

                context.ProdutoFinanceiros.Remove(produto);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }
    }
}