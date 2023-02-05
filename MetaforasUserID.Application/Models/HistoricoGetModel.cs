using MetaforasUserID.Domain.Entities;
using MetaforasUserID.Domain.Entities.Enum;

namespace MetaforasUserID.Application.Models
{
    public class HistoricoGetModel
    {
        public Guid Id { get; set; }
        public DateTime DataHoraOperacao { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public UsuarioGetModel Usuario { get; set; }
    }
}
