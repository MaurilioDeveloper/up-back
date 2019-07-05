using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Infrastructure;

namespace Positivo.AtividadesComplementares.Infrastructure.Repository
{
    public class AtividadeRepository : IAtividadeRepository
    {
        public readonly PositivoDbContext _context;
        private readonly IMapper _mapper;

        public AtividadeRepository(PositivoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SolicitacaoAtividadeLcsViewModel>> GetAtividades(int IdSolicitacao)
        {
            return _context.SolicitacaoAtividadeLcs
                .Include(sa => sa.IdAtividadeNavigation)
                .Where(sa => sa.IdSolicitacao == IdSolicitacao)
                .Select(sa => _mapper.Map<SolicitacaoAtividadeLcsViewModel>(sa))
                .ToList();
        }
    }
}