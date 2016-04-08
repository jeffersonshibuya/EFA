using System.Collections.Generic;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;

namespace Efa.Domain.Services
{
    public class ContatoGrupoService : ServiceBase<ContatoGrupo>, IContatoGrupoService
    {
        private readonly IContatoGrupoRepository _contatoGrupoRepository;

        public ContatoGrupoService(IContatoGrupoRepository contatoGrupoRepository): base(contatoGrupoRepository)
        {
            _contatoGrupoRepository = contatoGrupoRepository;
        }

        public IEnumerable<ContatoGrupo> GetGrupos()
        {
            return _contatoGrupoRepository.GetGrupos();
        }
    }
}