using app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xp_project.Models;
using xp_project.ViewModels;

namespace xp_project.Controllers
{
    [ApiController]
    [Route("v1/controle-investimento")]
    public class InvestimentoController : ControllerBase
    {
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetInvestimentosDetalhadosByIdUsuarioAsync(
            [FromServices] AppDbContext context,
            Guid userId)
        {
            var investimentosDetalhados = await context.ControleInvestimentos
                .AsNoTracking()
                .Where(ci => ci.IdUsuario == userId)
                .Join(context.ProdutoFinanceiros,
                      ci => ci.IdProdutoFinanceiro,
                      pf => pf.Id,
                      (ci, pf) => new InvestimentoDetalhadoViewModel
                      {
                          Id = ci.Id,
                          IdUsuario = ci.IdUsuario,
                          IdProdutoFinanceiro = ci.IdProdutoFinanceiro,
                          QuantidadeCotas = ci.QuantidadeCotas,
                          ValorCota = pf.ValorCota,
                          ValorTotalInvestimento = ci.QuantidadeCotas * pf.ValorCota,
                          Vencimento = pf.Vencimento
                      })
                .ToListAsync();

            return investimentosDetalhados == null || investimentosDetalhados.Count == 0
                ? NotFound()
                : Ok(investimentosDetalhados);
        }

        [HttpGet]
        [Route("{userId}/{idIvestimento}")]
        public async Task<IActionResult> GetInvestimentosDetalhadosByIdInvestimentoAsync(
            [FromServices] AppDbContext context,
            Guid userId,
            Guid idIvestimento)
        {
            var investimentosDetalhados = await context.ControleInvestimentos
                .AsNoTracking()
                .Where(ci => ci.IdUsuario == userId && ci.Id == idIvestimento)
                .Join(context.ProdutoFinanceiros,
                      ci => ci.IdProdutoFinanceiro,
                      pf => pf.Id,
                      (ci, pf) => new InvestimentoDetalhadoViewModel
                      {
                          Id = ci.Id,
                          IdUsuario = ci.IdUsuario,
                          IdProdutoFinanceiro = ci.IdProdutoFinanceiro,
                          QuantidadeCotas = ci.QuantidadeCotas,
                          ValorCota = pf.ValorCota,
                          ValorTotalInvestimento = ci.QuantidadeCotas * pf.ValorCota,
                          Vencimento = pf.Vencimento
                      })
                .ToListAsync();

            return investimentosDetalhados == null || investimentosDetalhados.Count == 0
                ? NotFound()
                : Ok(investimentosDetalhados);
        }

        [HttpPost]
        public async Task<IActionResult> PostInvestimentoAsync(
            [FromServices] AppDbContext context,
            [FromBody] PostControleInvestimentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var investimento = await context
                .ControleInvestimentos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdProdutoFinanceiro == model.IdProdutoFinanceiro 
                && x.IdUsuario == model.IdUsuario);

                if (investimento != null)
                {
                    /*
                     * TODO
                     * Documentar que esta condição significa que já existe um investimento para este usuário e este produto financeiro. 
                     * Para compra de mais cotas a rota PUT deve ser utilizada
                     */
                    return Conflict();
                }

                investimento = new ControleInvestimento
                {
                    IdUsuario = model.IdUsuario,
                    IdProdutoFinanceiro = model.IdProdutoFinanceiro,
                    QuantidadeCotas = model.QuantidadeCotas
                };

                await context.ControleInvestimentos.AddAsync(investimento);
                await context.SaveChangesAsync();
                return Created($"v1/controle-investimento/{investimento.Id}", investimento);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutInvestimentoAsync(
            [FromServices] AppDbContext context,
            [FromBody] PutControleInvestimentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var investimento = await context
                .ControleInvestimentos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdProdutoFinanceiro == model.IdProdutoFinanceiro
                && x.IdUsuario == model.IdUsuario);

                if (investimento == null)
                {
                    return NotFound();
                }
                if (model.QuantidadeCotas < 0 && model.QuantidadeCotas + investimento.QuantidadeCotas < 0)
                {
                    return BadRequest("A quantidade de cotas solicitada resultaria em um total negativo. A operação não pode ser realizada.");
                }

                investimento.IdUsuario = model.IdUsuario;
                investimento.IdProdutoFinanceiro = model.IdProdutoFinanceiro;
                investimento.QuantidadeCotas += model.QuantidadeCotas;

                context.ControleInvestimentos.Update(investimento);
                await context.SaveChangesAsync();
                return Ok(investimento);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor");
            }
        }

        [HttpDelete]
        [Route("{userId}/{idIvestimento}")]
        public async Task<IActionResult> DeleteInvestimentoAsync(
            [FromServices] AppDbContext context,
            [FromRoute] Guid userId,
            [FromRoute] Guid idIvestimento)
        {
            try
            {
                var investimento = await context
                .ControleInvestimentos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == idIvestimento && x.IdUsuario == x.IdUsuario);

                if (investimento == null)
                {
                    return NotFound();
                }

                context.ControleInvestimentos.Remove(investimento);
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
