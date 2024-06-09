namespace xp_project.ViewModels
{
    public class InvestimentoDetalhadoViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdProdutoFinanceiro { get; set; }
        public decimal QuantidadeCotas { get; set; }
        public decimal ValorCota { get; set; }
        public decimal ValorTotalInvestimento { get; set; }
        public DateTime Vencimento { get; set; }

    }
}
