using MetaforasUserID.Domain.Entities;

namespace MetaforasUserID.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        void Create(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario? GetByEmail(string email);
        Usuario? GetByEmailSenha(string email, string senha);
        Usuario GetUsuarioByToken(Guid token);
        void UsuarioPut(Usuario usuario);
        Usuario? GetUsuarioById(Guid id);
    }
}
