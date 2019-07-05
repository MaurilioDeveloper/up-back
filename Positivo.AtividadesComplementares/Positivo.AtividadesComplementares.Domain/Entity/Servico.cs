using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class Servico
    {
        public Servico()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        public int Id { get; set; }
        public string NmServico { get; set; }
        public string CodServico { get; set; }

        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
