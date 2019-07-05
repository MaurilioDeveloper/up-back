using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class Atividade
    {
        public Atividade()
        {
            SolicitacaoAtividadeLcs = new HashSet<SolicitacaoAtividadeLcs>();
        }

        public long Id { get; set; }
        public string DsAtividade { get; set; }
        public long CodAtividade { get; set; }

        public virtual ICollection<SolicitacaoAtividadeLcs> SolicitacaoAtividadeLcs { get; set; }
    }
}
