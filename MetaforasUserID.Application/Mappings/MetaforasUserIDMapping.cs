using AutoMapper;
using MetaforasUserID.Application.Models;
using MetaforasUserID.Domain.Entities;

namespace MetaforasUserID.Application.Mappings
{
    public class MetaforasUserIDMapping : Profile
    {

        public MetaforasUserIDMapping()
        {
            CreateMap<Usuario, UsuarioGetModel>().ReverseMap();
            CreateMap<Usuario, UsuarioRegisterModel>().ReverseMap();
            CreateMap<Usuario, RecoveryPasswordModel>().ReverseMap();
            CreateMap<Usuario, UsuarioPutModel>().ReverseMap();


            CreateMap<Historico, HistoricoGetModel>().ReverseMap();

        }
    }
}
