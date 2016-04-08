using System;
using Efa.Domain.Entities;
using System.Collections.Generic;

namespace Efa.Domain.Interfaces.Services
{
    public interface IContatoPessoaService : IServiceBase<ContatoPessoa>
    {
        IEnumerable<ContatoPessoa> GetContatos();
        void RemoveFromGroup(Guid idGrupo);
    }
}