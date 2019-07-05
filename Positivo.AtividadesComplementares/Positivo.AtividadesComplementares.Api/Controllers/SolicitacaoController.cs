
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Application.IService;
using Microsoft.Extensions.Logging;

namespace Positivo.AtividadesComplementares.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {       
        private readonly ILogger<SolicitacaoController> _log;
        private readonly ISolicitacaoService _service;
        public SolicitacaoController(ISolicitacaoService service, ILogger<SolicitacaoController> log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet("GetSolicitacoes/{idCurso}")]
        public ActionResult<List<SolicitacaoViewModel>> GetSolicitacoesByIdCurso(int idCurso)
        {
            _log.LogInformation($"==> Action GetSolicitacoesByIdCurso({idCurso}) :: SolicitacaoController -> executou " + DateTime.Now.ToLongTimeString());
            try
            {
                var retorno = _service.GetSolicitacoesByIdCurso(idCurso);

                if(retorno.Result.Count > 0)
                    return Ok(retorno);
            }
            catch(Exception e)
            {
                _log.LogError($"==> Action GetSolicitacoesByIdCurso({idCurso}) :: SolicitacaoController -> Erro: {e.Message} " + DateTime.Now.ToLongTimeString());
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição. Erro: {e.Message}");
            }

            _log.LogWarning($"==> Action GetSolicitacoesByIdCurso({idCurso}) :: SolicitacaoController -> NotFound " + DateTime.Now.ToLongTimeString());
            return NotFound();
        }

        [HttpPut("{idSolicitacao:int}")]
        public ActionResult Update(int idSolicitacao,  [FromBody] SolicitacaoViewModel solicitacao)
        {
            _log.LogInformation($"==> Action Update({idSolicitacao}, {solicitacao}) :: SolicitacaoController -> executou " + DateTime.Now.ToLongTimeString());
            try
            {
                _service.UpdateSolicitacoes(idSolicitacao, solicitacao);
                return Ok("Solicitação atualizada com sucesso");
            }
            catch(Exception e)
            {
                _log.LogError($"==> Action Update({idSolicitacao}, {solicitacao}) :: SolicitacaoController -> Erro: {e.Message} " + DateTime.Now.ToLongTimeString());
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição. Erro: {e.Message}");
            }
        }

        [HttpGet("CarregarCertificado/{idSolicitacao:int}")]
        public ActionResult CarregarCertificado(int idSolicitacao)
        {
            _log.LogInformation($"==> Action CarregarCertificado({idSolicitacao}) :: SolicitacaoController -> executou " + DateTime.Now.ToLongTimeString());
            try
            {
                var url = _service.GetUrlSolicitacao(idSolicitacao);

                if(url != null)
                {
                    WebClient myWebClient = new WebClient();

                    byte[] bytes = myWebClient.DownloadData(url);

                    return Ok(Convert.ToBase64String(bytes));
                }
            }
            catch(Exception e)
            {
                _log.LogError($"==> Action CarregarCertificado({idSolicitacao}) :: SolicitacaoController -> Erro: {e.Message} " + DateTime.Now.ToLongTimeString());
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição. Erro: {e.Message}");
            }
            
            _log.LogWarning($"==> Action CarregarCertificado({idSolicitacao}) :: SolicitacaoController -> NotFound " + DateTime.Now.ToLongTimeString());
            return NotFound();
        }
    }
}