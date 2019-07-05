using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class Aluno
    {
        public Aluno()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        public long Id { get; set; }
        public string NmAluno { get; set; }
        public long CodAluno { get; set; }

        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
