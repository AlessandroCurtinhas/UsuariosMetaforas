using MetaforasUserID.Domain.Entities;
using MetaforasUserID.Domain.Interfaces.Repositories;
using MetaforasUserID.Domain.Interfaces.Services;

namespace MetaforasUserID.Domain
{
    public class HistoricoService : IHistoricoService
    {
        private readonly IHistoricoRepository _historicoRepository;

        public HistoricoService(IHistoricoRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        public void Create(Historico historico)
        {
            _historicoRepository.Create(historico);
        }

        public IEnumerable<Historico>? GetAllByUusuario(Guid IdUsuario)
        {
            var historicos = _historicoRepository.GetAllByUusuario(IdUsuario);
            if (historicos == null) throw new ArgumentException("Nenhum histórico encontrado para o Usuario");
            
            return _historicoRepository.GetAllByUusuario(IdUsuario);
        }
    }
}
