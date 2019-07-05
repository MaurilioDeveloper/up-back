using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Api.ViewModel
{
    public class TipoCursoViewModel
    {
        public int Id { get; set; }
        public string NmTipoCurso { get; set; }

        public virtual ICollection<SolicitacaoViewModel> Solicitacao { get; }
    }
}