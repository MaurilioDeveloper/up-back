using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;

namespace Positivo.AtividadesComplementares.Infrastructure.IRepositoy
{
    public interface IAtividadeRepository
    {
        Task<List<SolicitacaoAtividadeLcsViewModel>> GetAtividades(int IdSolicitacao);
    }
}