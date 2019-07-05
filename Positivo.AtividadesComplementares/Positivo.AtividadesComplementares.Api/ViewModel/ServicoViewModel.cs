using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Api.ViewModel
{
    public class ServicoViewModel
    {
        public int Id { get; set; }
        public string NmServico { get; set; }
        public string CodServico { get; set; }

        public virtual ICollection<SolicitacaoViewModel> Solicitacao { get; set; }
    }
}