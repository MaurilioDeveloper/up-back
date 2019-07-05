using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Infrastructure;

namespace Positivo.AtividadesComplementares.Infrastructure.Repository
{
    public class TipoCursoRepository : ITipoCursoRepository
    {
         public readonly PositivoDbContext _context;
        private readonly IMapper _mapper;

        public TipoCursoRepository(PositivoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TipoCursoViewModel>> GetTipoCurso()
        {
            return _context.TipoCurso
            .Select(t => _mapper.Map<TipoCursoViewModel>(t))
            .ToList();
        }


    }
}