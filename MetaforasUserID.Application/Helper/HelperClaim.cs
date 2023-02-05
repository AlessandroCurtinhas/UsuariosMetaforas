using Microsoft.AspNetCore.Http;

namespace MetaforasUserID.Application.Helper
{
    public static class HelperClaim
    {
        public static Guid RetornaIdUsuarioToken(IHttpContextAccessor context)
        {
            var idUsuario = context.HttpContext.User.Claims;
            var claimUsuario = idUsuario.First().Value.ToString();

            return Guid.Parse(claimUsuario);

        }
    }
}
