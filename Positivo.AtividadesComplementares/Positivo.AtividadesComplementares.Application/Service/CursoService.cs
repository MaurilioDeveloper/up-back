using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Application.IService;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using Positivo.AtividadesComplementares.Infrastructure.Repository;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Infrastructure;

namespace Positivo.AtividadesComplementares.Application.Service
{
    public class CursoService : ICursoService
    {
        public readonly ICursoRepository _repository; 

        public CursoService(ICursoRepository repository)
        {
               _repository = repository; 
        }
        
        public async Task<List<CursoViewModel>> GetCursos()
        {
            return await _repository.GetCursos();
        }
    }
}