using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;

namespace Positivo.AtividadesComplementares.Application.IService
{
    public interface ISolicitacaoService
    {
        Task<List<SolicitacaoViewModel>> GetSolicitacoesByIdCurso(int idCurso);         
        void UpdateSolicitacoes(int idSolicitacao, SolicitacaoViewModel solicitacao);
        string GetUrlSolicitacao(int idSolicitacao);

    }
}