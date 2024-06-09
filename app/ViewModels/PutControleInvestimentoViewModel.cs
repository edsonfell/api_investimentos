using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace xp_project.ViewModels
{
    public class PutControleInvestimentoViewModel
    {
        [Required]
        public Guid IdUsuario { get; set; }
        [Required]
        public Guid IdProdutoFinanceiro { get; set; }
        
        [Required]
        [NonZero]
        public int QuantidadeCotas { get; set; }
    }
}
