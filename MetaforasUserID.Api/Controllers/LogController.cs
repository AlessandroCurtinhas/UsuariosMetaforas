using MetaforasUserID.Application.Interfaces;
using MetaforasUserID.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaforasUserID.Controllers
{
    [Authorize]
    [Route("MetaforasUserID/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly IHistoricoApplicationService _historicoApplicationService;

        public LogController(IHistoricoApplicationService historicoApplicationService)
        {
            _historicoApplicationService = historicoApplicationService;
        }

        [ProducesResponseType(200, Type = typeof(HistoricoGetModel))]
        [HttpGet("{idUsuario}")]
        public IActionResult GetById(Guid idUsuario)
        {
            try
            {
                var historicos = _historicoApplicationService.GetAllByUsuario(idUsuario);
                return StatusCode(200, historicos);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}
