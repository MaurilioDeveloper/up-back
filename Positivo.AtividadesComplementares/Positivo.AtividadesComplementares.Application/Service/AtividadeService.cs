using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Application.IService;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;

namespace Positivo.AtividadesComplementares.Application.Service
{
    public class AtividadeService : IAtividadeService
    {
        public readonly IAtividadeRepository _repository; 

        public AtividadeService(IAtividadeRepository repository)
        {
               _repository = repository; 
        }

        public async Task<List<SolicitacaoAtividadeLcsViewModel>> GetAtividades(int IdSolicitacao)
        {
            return await _repository.GetAtividades(IdSolicitacao);
        }
    }
}