using MetaforasUserID.Application.Models;
using MetaforasUserID.Domain.Entities.Enum;

namespace MetaforasUserID.Application.Interfaces
{
    public interface IHistoricoApplicationService
    {
        public void Create(Guid idUsuario, TipoOperacao tipoOperacao);
        public List<HistoricoGetModel> GetAllByUsuario(Guid idUsuario);
    }
}
