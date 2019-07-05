using AutoMapper;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity;

namespace Positivo.AtividadesComplementares.Infrastructure.Mapper
{
    public class MapperRepository : Profile
    {
        public MapperRepository()
        {
            CreateMap<CursoViewModel, Curso>();
            CreateMap<TipoCursoViewModel, TipoCurso>();

            CreateMap<SolicitacaoAtividadeLcs, SolicitacaoAtividadeLcsViewModel>()
                .ForMember(dest => dest.AtividadeNavigation, opt => opt.MapFrom(src => src.IdAtividadeNavigation));

            CreateMap<Solicitacao, SolicitacaoViewModel>()
                .ForMember(dest => dest.TipoCursoNavigation, opt => opt.MapFrom(src => src.IdTipoCursoNavigation))
                .ForMember(dest => dest.AlunoNavigation, opt => opt.MapFrom(src => src.IdAlunoNavigation))
                .ForMember(dest => dest.CursoNavigation, opt => opt.MapFrom(src => src.IdCursoNavigation))
                .ForMember(dest => dest.ServicoNavigation, opt => opt.MapFrom(src => src.IdServicoNavigation));

            CreateMap<Solicitacao, SolicitacaoViewModel>()
                .ForMember(dest => dest.TipoCursoNavigation, opt => opt.MapFrom(src => src.IdTipoCursoNavigation))
                .ForMember(dest => dest.AlunoNavigation, opt => opt.MapFrom(src => src.IdAlunoNavigation))
                .ForMember(dest => dest.CursoNavigation, opt => opt.MapFrom(src => src.IdCursoNavigation))
                .ForMember(dest => dest.ServicoNavigation, opt => opt.MapFrom(src => src.IdServicoNavigation))
            .ReverseMap();
            
        }
    }
}