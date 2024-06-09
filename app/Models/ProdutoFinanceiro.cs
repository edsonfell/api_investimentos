using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace xp_project.Models
{
    [Table("produtos_financeiros")]
    public class ProdutoFinanceiro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("nome")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("valor_cota")]
        public decimal ValorCota { get; set; }

        [Column("vencimento")]
        public DateTime Vencimento { get; set; }
    }
}
