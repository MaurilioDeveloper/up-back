using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Application.IService;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;

namespace Positivo.AtividadesComplementares.Application.Service
{
    public class TipoCursoService : ITipoCursoService
    {
        ITipoCursoRepository _repository;
        public TipoCursoService(ITipoCursoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TipoCursoViewModel>> GetTipoCurso()
        {
            return await _repository.GetTipoCurso();
        }
        
    }
}