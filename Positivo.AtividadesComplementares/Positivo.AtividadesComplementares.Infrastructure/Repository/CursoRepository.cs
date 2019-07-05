using System.Linq;
using AutoMapper;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Infrastructure;
using Positivo.AtividadesComplementares.Api.ViewModel;
using System.Collections.Generic;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Positivo.AtividadesComplementares.Infrastructure.Repository
{
    public class CursoRepository : ICursoRepository
    {
        public readonly PositivoDbContext _context;
        private readonly IMapper _mapper;

        public CursoRepository(PositivoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CursoViewModel>> GetCursos()
        {
             return _context.Curso
                .Where(c => _context.Solicitacao
                    .Where(s => s.IdCurso == c.Id)
                    .Where(s => s.FlStatus.ToUpper().Equals("P"))
                    .Select(s => s.IdCurso)
                    .Any())
                .AsNoTracking()
                .Select(c => _mapper.Map<CursoViewModel>(c))
                .ToList();
        }
    }
}