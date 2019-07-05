namespace Positivo.AtividadesComplementares.Api.ViewModel
{
    public class SolicitacaoAtividadeLcsViewModel
    {
        public long Id { get; set; }
        public long IdAtividade { get; set; }
        public long IdSolicitacao { get; set; }
        public int AnoAtividade { get; set; }
        public string CargaHoraria { get; set; }
        
        public virtual AtividadeViewModel AtividadeNavigation { get; set; }
        public virtual SolicitacaoViewModel SolicitacaoNavigation { get; set; }
    }
}