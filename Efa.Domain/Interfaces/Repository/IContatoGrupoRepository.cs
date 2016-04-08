using System.Collections.Generic;
using Efa.Domain.Entities;

namespace Efa.Domain.Interfaces.Repository
{
    public interface IContatoGrupoRepository : IRepositoryBase<ContatoGrupo>
    {
        IEnumerable<ContatoGrupo> GetGrupos();
    }
}