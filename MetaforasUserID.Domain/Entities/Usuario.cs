using MetaforasUserID.Domain.Entities.Enum;

namespace MetaforasUserID.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Guid? TokenRecovery { get; set; }
        public DateTime? TokenExpiracao { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
        public Boolean Ativo { get; set; }
        
        public Perfil Perfil { get; set; }
        public List<Historico>? Historico { get; set; }

    }
}
