using Microsoft.AspNetCore.Mvc;
using MetaforasUserID.Application.Models;
using MetaforasUserID.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MetaforasUserID.Controllers
{
    [Route("MetaforasUserID/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountApplicationService _serviceApplication;

        public AccountController(IAccountApplicationService serviceApplication)
        {
            _serviceApplication = serviceApplication;
        }

        [HttpPost("login/")]
        public IActionResult Login(UsuarioLoginModel model)
        {
            try
            {
                var token = _serviceApplication.Login(model);
                return StatusCode(200,token);
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

        [HttpPost("register/")]
        public IActionResult Register(UsuarioRegisterModel model)
        {
            try
            {
                _serviceApplication.Register(model);
                return StatusCode(201, new { mensagem = "Usuario criado com sucesso." });
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

        [HttpPost("recovery/")]
        public IActionResult RecoveryPassword(RecoveryPasswordModel model)
        {
            try
            {
                _serviceApplication.Recovery(model);
                return StatusCode(200, new { mensagem = "Senha Atualizada com sucesso!" });
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

        [Authorize]
        [HttpPut("updateUser/")]
        public IActionResult Update(UsuarioPutModel model)
        {
            try
            {
                _serviceApplication.UsuarioPut(model);
                return StatusCode(200, new { mensagem = "Dados Atualizados com Sucesso!" });
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

        [HttpPost("requestRecovery/")]
        public IActionResult RecoveryRequestPassword(UsuarioRequestRecoveryPassword model)
        {
            try
            {
                _serviceApplication.RequestRecoveryPassword(model);
                return StatusCode(200, new { mensagem = "Solictação de reset de senha realizada com sucesso. Você receberá um email para resetar a sua senha." });
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

        [HttpGet("requestRecovery/{token}")]
        public IActionResult RecoveryPassword(Guid token)
        {
            try
            {
                var email = _serviceApplication.GetUsuarioByTokenRecovery(token);
                return StatusCode(200,email);
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
