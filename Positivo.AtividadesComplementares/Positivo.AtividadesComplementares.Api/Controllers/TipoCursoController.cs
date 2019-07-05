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
    public class TipoCursoController : ControllerBase
    {
        private readonly ILogger<TipoCursoController> _log;
        public readonly ITipoCursoService _service;
        public TipoCursoController(ITipoCursoService service, ILogger<TipoCursoController> log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet("get")]
        public ActionResult<List<TipoCursoViewModel>> Get()
        {
            _log.LogInformation($"==> Action Get :: TipoCursoController -> executou " + DateTime.Now.ToLongTimeString());
            try
            {
                return Ok(_service.GetTipoCurso());
            }
            catch(Exception e)
            {
                _log.LogError($"==> Action Get :: TipoCursoController -> Erro: {e.Message} " + DateTime.Now.ToLongTimeString());
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição. Erro: {e.Message}");
            }
        }
    }
}