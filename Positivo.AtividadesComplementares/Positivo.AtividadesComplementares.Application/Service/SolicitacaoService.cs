using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Application.IService;
using Positivo.AtividadesComplementares.Domain.Infrastructure;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity;

namespace Positivo.AtividadesComplementares.Application.Service
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly IMapper _mapper;
        public readonly ISolicitacaoRepository _repository; 

        public SolicitacaoService(ISolicitacaoRepository repository, IMapper mapper)
        {
               _repository = repository;
               _mapper = mapper; 
        }
        
        public async Task<List<SolicitacaoViewModel>> GetSolicitacoesByIdCurso(int idCurso)
        {
            return await _repository.GetSolicitacoesByIdCurso(idCurso);
        }

        public void UpdateSolicitacoes(int idSolicitacao, SolicitacaoViewModel model)
        {
            Solicitacao oldSolicitacao = _repository.Find((long) idSolicitacao);

            if (!oldSolicitacao.FlStatus.Equals("P")) {
                throw new Exception("Está solicitação já foi atualizada");
            }

            Solicitacao novaSolicitacao = _mapper.Map<Solicitacao>(model);

            _repository.UpdateAsync(novaSolicitacao);
        }

        public string GetUrlSolicitacao(int idSolicitacao)
        {
            var url = _repository.GetUrlSolicitacao(idSolicitacao).Trim();

            // if(!url.ToUpper().EndsWith(".PDF"))
            // {
            //     throw new Exception("Processo disponivel apenas para arquivos PDF");
            // }

            return url;
        }

    }
}