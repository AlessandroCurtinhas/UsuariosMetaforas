using MetaforasUserID.Application.Models;

namespace MetaforasUserID.Application.Interfaces
{
    public interface IAccountApplicationService
    {
        void Register(UsuarioRegisterModel model);
        UsuarioGetModel Login(UsuarioLoginModel model);
        void RequestRecoveryPassword(UsuarioRequestRecoveryPassword model);
        string GetUsuarioByTokenRecovery(Guid token);
        void Recovery(RecoveryPasswordModel model);
        void UsuarioPut(UsuarioPutModel model);
    }
}
