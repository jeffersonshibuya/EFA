using System;
using System.Collections.Generic;
using Efa.Domain.Entities;

namespace Efa.Domain.Interfaces.Repository
{
    public interface IContatoPessoaRepository : IRepositoryBase<ContatoPessoa>
    {
        IEnumerable<ContatoPessoa> GetContatos();
        void RemoveFromGroup(Guid idGrupo);
    }
}