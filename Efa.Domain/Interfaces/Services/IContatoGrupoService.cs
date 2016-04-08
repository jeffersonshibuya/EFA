using Efa.Domain.Entities;
using System.Collections.Generic;

namespace Efa.Domain.Interfaces.Services
{
    public interface IContatoGrupoService : IServiceBase<ContatoGrupo>
    {
        IEnumerable<ContatoGrupo> GetGrupos();
    }
}