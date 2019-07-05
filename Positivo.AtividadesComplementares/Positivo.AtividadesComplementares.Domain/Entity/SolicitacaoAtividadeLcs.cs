using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class SolicitacaoAtividadeLcs
    {
        public long Id { get; set; }
        public long IdAtividade { get; set; }
        public long IdSolicitacao { get; set; }
        public int AnoAtividade { get; set; }
        public string CargaHoraria { get; set; }

        public virtual Atividade IdAtividadeNavigation { get; set; }
        public virtual Solicitacao IdSolicitacaoNavigation { get; set; }
    }
}
