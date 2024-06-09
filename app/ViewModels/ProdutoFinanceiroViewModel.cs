using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace xp_project.ViewModels
{
    public class ProdutoFinanceiroViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal ValorCota { get; set; }
        [Required]
        public DateTime Vencimento { get; set; }
    }
}
