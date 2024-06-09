using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace xp_project.ViewModels
{
    public class ProdutoFinanceiroViewModel : IValidatableObject
    {
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Descricao { get; set; }
        
        [Required]
        public decimal ValorCota { get; set; }
        
        [Required]
        public DateTime Vencimento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Vencimento <= DateTime.Today)
            {
                yield return new ValidationResult("A data de vencimento deve ser maior que a data atual.");
            }
        }
    }
}
