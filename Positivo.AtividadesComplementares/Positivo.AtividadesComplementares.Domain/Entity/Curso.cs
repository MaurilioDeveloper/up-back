using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class Curso
    {
        public Curso()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        public int Id { get; set; }
        public int CodCurso { get; set; }
        public string NmCurso { get; set; }

        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
