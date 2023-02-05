using MetaforasUserID.Domain.Entities;

namespace MetaforasUserID.Domain.Interfaces.Repositories
{
    public interface IHistoricoRepository
    {
        void Create(Historico historico);
        IEnumerable<Historico>? GetAllByUusuario(Guid IdUsuario);
    }
}
