using MetaforasUserID.Domain.Entities.Enum;

namespace MetaforasUserID.Application.Models
{
    public class UsuarioGetModel
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Perfil Perfil { get; set; }
        public String Email { get; set; }
        public string Token { get; set; }
    }
}
