using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Application.IService;

namespace Positivo.AtividadesComplementares.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly ILogger<AtividadeController> _log;
        private readonly IAtividadeService _service;
        public AtividadeController(IAtividadeService service, ILogger<AtividadeController> log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet("GetAtividadeBySolicitacao/{IdSolicitacao}")]
        public ActionResult<List<SolicitacaoAtividadeLcsViewModel>> GetAtividadeBySolicitacao(int IdSolicitacao)
        {
            _log.LogInformation($"==> Action GetAtividadeBySolicitacao({IdSolicitacao}) :: AtividadeController -> executou " + DateTime.Now.ToLongTimeString());

            try
            {
                var atividades = _service.GetAtividades(IdSolicitacao);

                return Ok(atividades);
            }
            catch(Exception ex)
            {
                _log.LogError($"==> Action GetAtividadeBySolicitacao({IdSolicitacao}) :: AtividadeController -> Erro: {ex.Message} " + DateTime.Now.ToLongTimeString());
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição. Erro: {ex.Message}");
            }
        }
    }
}