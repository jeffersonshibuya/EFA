using System.Collections.Generic;
using Efa.Domain.Entities;

namespace Efa.Domain.Interfaces.Repository
{
    public interface IAlunoRepositoryReadOnly
    {
        IEnumerable<Aluno> GetAll();
    }
}