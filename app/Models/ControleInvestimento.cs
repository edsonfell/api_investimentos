using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace xp_project.Models
{
    [Table("controle_investimentos")]
    public class ControleInvestimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey("ProdutoFinanceiro")]
        [Column("id_produto_financeiros")]
        public Guid IdProdutoFinanceiro { get; set; }

        [Column("quantidade_cotas")]
        public decimal QuantidadeCotas { get; set; }

        public Usuario Usuario { get; set; }
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }
    }
}
