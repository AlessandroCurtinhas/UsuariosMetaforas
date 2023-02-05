using MetaforasUserID.Domain.Entities;
using MetaforasUserID.Domain.Helpers;
using MetaforasUserID.Domain.Interfaces.Repositories;
using MetaforasUserID.Domain.Interfaces.Services;

namespace MetaforasUserID.Domain
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Atualizar(Usuario usuario)
        {
            var usuarioRepository = GetByEmail(usuario.Email);
            if (usuarioRepository == null) throw new ArgumentException("Não foi possível encontrar o usuário informado.");

            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);
            _usuarioRepository.Atualizar(usuario);
        }

        public void Create(Usuario usuario)
        {
            var usuarioRepository = GetByEmail(usuario.Email);
            if (usuarioRepository != null) throw new ArgumentException("O email informado já está sendo usado por outro usuário.");

            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            _usuarioRepository.Create(usuario);
            
        }

        public void UsuarioPut(Usuario usuario)
        {
            var usuarioEmail = GetByEmail(usuario.Email);
            if(usuarioEmail != null && usuarioEmail.Id != usuario.Id ) throw new ArgumentException("O email informado já está sendo usado ou usuário não foi encontrado.");
            _usuarioRepository.Atualizar(usuario);
        }


        public Usuario? GetByEmail(string email)
        {
            var usuario = _usuarioRepository.GetByEmail(email);
            if(usuario == null) return null;

            return usuario;
        }

        public Usuario? GetByEmailSenha(string email, string senha)
        {
            var usuario = _usuarioRepository.GetByEmailSenha(email, MD5Helper.Encrypt(senha));
            if (usuario == null) throw new ArgumentException("Usuario ou Senha incorretos.");

            return usuario;
        }

        public Usuario? GetUsuarioById(Guid IdUsuario)
        {
            var usuario = _usuarioRepository.GetById(IdUsuario);
            if (usuario == null) throw new ArgumentException("Não foi encontrado usuário associado ao Id informado.");

            return usuario;
        }

        public Usuario GetUsuarioByToken(Guid token)
        {
            var usuario = _usuarioRepository.GetUsuarioByToken(token);
            if (usuario == null || ValidaTempoToken(usuario)) throw new ArgumentException("Não foi encontrada nenhuma solicitação recuperação de senha válida.");

            return usuario;

        }

        private bool ValidaTempoToken(Usuario usuario)
        {
            var retorno = DateTime.UtcNow > usuario.TokenExpiracao.Value;
            return retorno;
        }
    }
}
