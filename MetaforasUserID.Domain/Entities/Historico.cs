using MetaforasUserID.Domain.Entities.Enum;

namespace MetaforasUserID.Domain.Entities
{
    public class Historico
    {
        public Guid Id { get; set; }
        public DateTime DataHoraOperacao { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
