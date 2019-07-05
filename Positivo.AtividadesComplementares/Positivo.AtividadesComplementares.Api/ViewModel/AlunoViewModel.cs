using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Api.ViewModel
{
    public class AlunoViewModel
    {
        public long Id { get; set; }
        public string NmAluno { get; set; }
        public long CodAluno { get; set; }

        public virtual ICollection<SolicitacaoViewModel> Solicitacao { get; }
    }
}