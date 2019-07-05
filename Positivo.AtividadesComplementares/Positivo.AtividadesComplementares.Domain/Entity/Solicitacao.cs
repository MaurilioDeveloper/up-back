using System;
using System.Collections.Generic;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity
{
    public partial class Solicitacao
    {
        public Solicitacao()
        {
            SolicitacaoAtividadeLcs = new HashSet<SolicitacaoAtividadeLcs>();
        }

        public long Id { get; set; }
        public long CodSolicitacao { get; set; }
        public DateTime DtSolicitacao { get; set; }
        public string DsAtividade { get; set; }
        public decimal? HorasSolicitadas { get; set; }
        public decimal? HorasDeferidas { get; set; }
        public DateTime? DhInicio { get; set; }
        public DateTime? DhFim { get; set; }
        public string DsUrlArquivo { get; set; }
        public long IdAluno { get; set; }
        public int IdCurso { get; set; }
        public int IdServico { get; set; }
        public int? IdTipoCurso { get; set; }
        public string FlStatus { get; set; }
        public string FlAvaliacaoRpa { get; set; }
        public string NmUsuario { get; set; }
        public DateTime? DhUpdate { get; set; }
        public bool? FlCertificadoPositivo { get; set; }
        public string DsMotivo { get; set; }
        public string DsMotivoRpa { get; set; }
        public bool? FlValidacaoAluno { get; set; }
        public bool? FlValidacaoAtividade { get; set; }
        public bool? FlValidacaoData { get; set; }
        public bool? FlValidacaoHoras { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Servico IdServicoNavigation { get; set; }
        public virtual TipoCurso IdTipoCursoNavigation { get; set; }
        public virtual ICollection<SolicitacaoAtividadeLcs> SolicitacaoAtividadeLcs { get; set; }
    }
}
