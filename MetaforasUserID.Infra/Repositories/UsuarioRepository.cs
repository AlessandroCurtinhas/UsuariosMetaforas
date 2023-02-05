using MetaforasUserID.Domain.Entities;
using MetaforasUserID.Domain.Interfaces.Repositories;
using MetaforasUserID.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MetaforasUserID.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DbPostgresContext _context;

        public UsuarioRepository(DbPostgresContext context)
        {
            _context = context;
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }

        public void Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario? GetByEmail(string email)
        {
            IQueryable<Usuario> query = _context.Usuario;

            return query.AsNoTracking().FirstOrDefault(p => p.Email.Equals(email));

        }

        public Usuario? GetById(Guid? idUSuario)
        {
            IQueryable<Usuario> query = _context.Usuario;

            return query.FirstOrDefault(p => p.Id.Equals(idUSuario));

        }

        public Usuario? GetByEmailSenha(string email, string senha)
        {
            IQueryable<Usuario> query = _context.Usuario;

            return query.FirstOrDefault(p => p.Email.Equals(email) && p.Senha.Equals(senha));
        }
        public Usuario? GetUsuarioByToken(Guid Token)
        {
            IQueryable<Usuario> query = _context.Usuario;

            return query.FirstOrDefault(p => p.TokenRecovery.Equals(Token));
        }
    }
}
