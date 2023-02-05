using MetaforasUserID.Domain.Entities;

namespace MetaforasUserID.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario? GetByEmail(string email);
        Usuario? GetByEmailSenha(string email, string senha);
        public Usuario? GetUsuarioByToken(Guid Token);
        public Usuario? GetById(Guid? idUSuario);
    }
}
