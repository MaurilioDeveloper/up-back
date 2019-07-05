using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Positivo.AtividadesComplementares.Api.ViewModel;
using Positivo.AtividadesComplementares.Application.IService;

namespace Positivo.AtividadesComplementares.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {       
        private readonly ICursoService _service;
        private readonly ILogger<CursoController> _log;

        public CursoController(ICursoService service, ILogger<CursoController> log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet("GetCurso")]
        public ActionResult<List<CursoViewModel>> GetCurso()
        {
            _log.LogInformation("==> Action GetCurso :: CursoController -> executou " + DateTime.Now.ToLongTimeString());

            try
            {
                var cursos = _service.GetCursos();
                return Ok(cursos);
            }
            catch(Exception ex)
            {
                _log.LogError($"==> Action GetCurso :: CursoController -> Erro: {ex.Message} " + DateTime.Now.ToLongTimeString());
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição. Erro: {ex.Message}");
            }
        }
    }
}