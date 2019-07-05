using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class Execucao
    {
        public long Id { get; set; }
        public DateTime DhExecucao { get; set; }
        public string FlStatus { get; set; }
        public int NumTentativas { get; set; }
    }
}
