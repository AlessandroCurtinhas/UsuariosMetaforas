using AutoMapper;
using MetaforasUserID.Application.Helper;
using MetaforasUserID.Application.Interfaces;
using MetaforasUserID.Application.Models;
using MetaforasUserID.Domain.Entities;
using MetaforasUserID.Domain.Entities.Enum;
using MetaforasUserID.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace MetaforasUserID.Application
{
    public class HistoricoApplicationService : IHistoricoApplicationService
    {
        private readonly IHistoricoService _historicoService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _user;
        public HistoricoApplicationService(IHistoricoService historicoService, IMapper mapper, IHttpContextAccessor user)
        {
            _historicoService = historicoService;
            _mapper = mapper;
            _user = user;
        }

        public void Create(Guid idUsuario, TipoOperacao tipoOperacao )
        {
            var historico = new Historico
            {
                Id = Guid.NewGuid(),
                UsuarioId = idUsuario,
                DataHoraOperacao = DateTime.UtcNow,
                TipoOperacao = tipoOperacao
            };

            _historicoService.Create(historico);

        }

        public List<HistoricoGetModel> GetAllByUsuario(Guid idUsuario)
        {
            var idUsuarioToken = HelperClaim.RetornaIdUsuarioToken(_user);

            if(idUsuarioToken != idUsuario)
            {
                Create(idUsuarioToken, TipoOperacao.OperacaoIndevida);
                throw new ArgumentException("Impossível realizar a operação.");
            }

            var historicos = _historicoService.GetAllByUusuario(idUsuario);
            var historicosGetModel = _mapper.Map<List<HistoricoGetModel>>(historicos);
            var historicosOrdenados = historicosGetModel.OrderBy(p => p.DataHoraOperacao).ToList();
            return historicosOrdenados;
        }

    }
}
