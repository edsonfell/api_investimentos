using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace xp_project.ViewModels
{
    public class PostControleInvestimentoViewModel
    {
        [Required]
        public Guid IdUsuario { get; set; }
        [Required]
        public Guid IdProdutoFinanceiro { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de cotas deve ser maior que zero.")]
        public int QuantidadeCotas { get; set; }
    }
}
