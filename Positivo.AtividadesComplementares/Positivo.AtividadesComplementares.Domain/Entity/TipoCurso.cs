using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class TipoCurso
    {
        public TipoCurso()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        public int Id { get; set; }
        public string NmTipoCurso { get; set; }

        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
