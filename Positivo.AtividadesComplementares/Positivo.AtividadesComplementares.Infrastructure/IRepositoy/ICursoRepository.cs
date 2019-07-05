using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;

namespace Positivo.AtividadesComplementares.Infrastructure.IRepositoy
{
    public interface ICursoRepository
    {
        Task<List<CursoViewModel>> GetCursos();
    }
}