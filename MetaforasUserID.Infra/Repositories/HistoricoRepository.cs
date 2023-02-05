using MetaforasUserID.Domain.Entities;
using MetaforasUserID.Domain.Interfaces.Repositories;
using MetaforasUserID.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MetaforasUserID.Infra.Repositories
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly DbPostgresContext _context;

        public HistoricoRepository(DbPostgresContext context)
        {
            _context = context;
        }

        public void Create(Historico historico)
        {
            _context.Historico.Add(historico);
            _context.SaveChanges();
        }

        public IEnumerable<Historico> GetAllByUusuario(Guid IdUsuario)
        {
            IQueryable<Historico> query = _context.Historico;
            return query.AsNoTracking()
                        .Include(p => p.Usuario)
                        .Where(p => p.UsuarioId.Equals(IdUsuario)).ToList();
        }

    }
}
