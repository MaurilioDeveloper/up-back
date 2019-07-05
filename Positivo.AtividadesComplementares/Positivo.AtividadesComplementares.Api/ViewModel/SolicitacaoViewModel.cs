using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Positivo.AtividadesComplementares.Api.ViewModel
{
    public class SolicitacaoViewModel
    {
        [Required(ErrorMessage="Id é obrigatório")]
        public long Id { get; set; }

        public long CodSolicitacao { get; set; }

        public DateTime DtSolicitacao { get; set; }

        public string DsAtividade { get; set; }

        [Required(ErrorMessage="Id é obrigatório")]
        public decimal? HorasSolicitadas { get; set; }

        [Required(ErrorMessage="Carga horaria deferida é obrigatório")]
        public decimal? HorasDeferidas { get; set; }

        [Required(ErrorMessage="Data início é obrigatório")]
        public DateTime? DhInicio { get; set; }

        [Required(ErrorMessage="Data fim é obrigatório")]
        public DateTime? DhFim { get; set; }

        public string DsUrlArquivo { get; set; }

        public long IdAluno { get; set; }

        public int IdCurso { get; set; }

        public int IdServico { get; set; }

        [Required(ErrorMessage="Tipo curso é obrigatório")]
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
     
        public virtual AlunoViewModel AlunoNavigation { get; set; }

        public virtual CursoViewModel CursoNavigation { get; set; }

        public virtual ServicoViewModel ServicoNavigation { get; set; }

        [Required(ErrorMessage="Tipo curso é obrigatório")]
        public virtual TipoCursoViewModel TipoCursoNavigation { get; set; }
        
        public virtual ICollection<SolicitacaoAtividadeLcsViewModel> SolicitacaoAtividadeLcs { get; set; }
    }
}