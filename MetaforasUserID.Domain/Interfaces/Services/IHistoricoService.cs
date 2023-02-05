using MetaforasUserID.Domain.Entities;

namespace MetaforasUserID.Domain.Interfaces.Services
{
    public interface IHistoricoService
    {
        void Create(Historico historico);
        IEnumerable<Historico>? GetAllByUusuario(Guid IdUsuario);
    }
}
