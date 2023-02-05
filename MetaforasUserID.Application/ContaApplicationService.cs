using AutoMapper;
using MetaforasUserID.Application.Helper;
using MetaforasUserID.Application.Interfaces;
using MetaforasUserID.Application.Models;
using MetaforasUserID.Application.Security;
using MetaforasUserID.Domain.Entities;
using MetaforasUserID.Domain.Entities.Enum;
using MetaforasUserID.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;


namespace MetaforasUserID.Application
{
    public class ContaApplicationService : IAccountApplicationService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IHistoricoApplicationService _historicoApplicationService;
        private readonly IHttpContextAccessor _user;
        private readonly IMapper _mapper;

        public ContaApplicationService(IUsuarioService usuarioService, IHistoricoApplicationService historicoService, IMapper mapper, IHttpContextAccessor user)
        {
            _usuarioService = usuarioService;
            _historicoApplicationService = historicoService;
            _mapper = mapper;
            _user = user;
        }

        public void Register(UsuarioRegisterModel model)
        {

            var usuario = _mapper.Map<Usuario>(model);
            usuario.Id = Guid.NewGuid();
            usuario.Perfil = Perfil.Admin;
            usuario.Ativo = true;

            _usuarioService.Create(usuario);

            _historicoApplicationService.Create(usuario.Id, TipoOperacao.Criacao);

        }

        public UsuarioGetModel Login(UsuarioLoginModel model)
        {
            var usuario = _usuarioService.GetByEmailSenha(model.Email, model.Senha);
            var token = JWTService.GenerateToken(usuario);

            var usarioGetModel = _mapper.Map<UsuarioGetModel>(usuario);
            usarioGetModel.Token = token;

            _historicoApplicationService.Create(usuario.Id, TipoOperacao.Autenticacao);

            return usarioGetModel;

        }

        public void RequestRecoveryPassword(UsuarioRequestRecoveryPassword model)
        {
            var usuario = _usuarioService.GetByEmail(model.Email);
            if (usuario == null) throw new ArgumentException("Não foi possível encontrar o email informado.");
            usuario.TokenRecovery = Guid.NewGuid();
            usuario.TokenExpiracao = DateTime.UtcNow.AddMinutes(30);
            _usuarioService.Atualizar(usuario);

            _historicoApplicationService.Create(usuario.Id, TipoOperacao.SolicitaçãoAlteracaoSenha);
        }

        public string GetUsuarioByTokenRecovery(Guid token)
        {
            var usuario = _usuarioService.GetUsuarioByToken(token);
            return usuario.Email;

        }

        public void UsuarioPut(UsuarioPutModel model)
        {
            var usuario = _usuarioService.GetUsuarioById(model.Id);

            var idUsuarioToken = HelperClaim.RetornaIdUsuarioToken(_user);

            if (idUsuarioToken != model.Id)
            {
                _historicoApplicationService.Create(idUsuarioToken, TipoOperacao.OperacaoIndevida);
                throw new ArgumentException("Impossível realizar atualização.");
            }

            usuario.Nome = model.Nome;
            usuario.Email = model.Email;

           _usuarioService.UsuarioPut(usuario);

           _historicoApplicationService.Create(model.Id, TipoOperacao.AlteracaoDadosPessoais);

        }

        public void Recovery(RecoveryPasswordModel model)
        {
            var usuario = _usuarioService.GetUsuarioByToken(model.Token);
            if (usuario.Email != model.Email) throw new ArgumentException ("Impossível realizar operação.");
            usuario.Senha = model.Senha;
            usuario.TokenRecovery = null;
            usuario.TokenExpiracao = null;
            _usuarioService.Atualizar(usuario);

            _historicoApplicationService.Create(usuario.Id, TipoOperacao.AlteracaoSenha);

        }

    }
}
