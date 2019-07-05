using System.Collections.Generic;
using System.Threading.Tasks;
using Positivo.AtividadesComplementares.Api.ViewModel;

namespace Positivo.AtividadesComplementares.Infrastructure.IRepositoy
{
    public interface ITipoCursoRepository
    {
        Task<List<TipoCursoViewModel>> GetTipoCurso();
    }
}