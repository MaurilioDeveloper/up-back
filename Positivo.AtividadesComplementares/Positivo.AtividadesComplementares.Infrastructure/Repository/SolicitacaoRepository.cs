using System.Linq;
using AutoMapper;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Infrastructure;
using Positivo.AtividadesComplementares.Api.ViewModel;
using System.Collections.Generic;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Positivo.AtividadesComplementares.Domain.Infrastructure;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity;

namespace Positivo.AtividadesComplementares.Infrastructure.Repository
{
    public class SolicitacaoRepository : Repository<Solicitacao, long>, ISolicitacaoRepository
    {
        public readonly PositivoDbContext _context;
        private readonly IMapper _mapper;

        public SolicitacaoRepository(PositivoDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SolicitacaoViewModel>> GetSolicitacoesByIdCurso(int idCurso)
        {
             return _context
                .Solicitacao
                .Include(s => s.IdAlunoNavigation)
                .Include(s => s.IdCursoNavigation)
                .Include(s => s.IdTipoCursoNavigation)
                .Where(s => s.FlStatus.ToUpper().Equals("P"))
                .Where(s => s.IdCurso == idCurso)
                .Select(c => _mapper.Map<SolicitacaoViewModel>(c))
                .ToList();
        }

        public string GetUrlSolicitacao(int idSolicitacao)
        {
            var retorno = _context
                .Solicitacao
                .Where(s => s.Id == idSolicitacao)
                .Select(s => s.DsUrlArquivo)
                .FirstOrDefault();

            return retorno;
        }

    }
}