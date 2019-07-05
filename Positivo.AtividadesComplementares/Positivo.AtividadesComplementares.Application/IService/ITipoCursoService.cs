using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;

namespace Positivo.AtividadesComplementares.Application.IService
{
    public interface ITipoCursoService
    {
        Task<List<TipoCursoViewModel>> GetTipoCurso();
    }
}