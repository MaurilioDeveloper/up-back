using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity;

namespace Positivo.AtividadesComplementares.Domain.Infrastructure
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao, long>
    {
        Task<List<SolicitacaoViewModel>> GetSolicitacoesByIdCurso(int idCurso);  

        string GetUrlSolicitacao(int idSolicitacao);

    }
}