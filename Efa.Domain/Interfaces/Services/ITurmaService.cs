using System;
using System.Collections.Generic;
using Efa.Domain.Entities;

namespace Efa.Domain.Interfaces.Services
{
    public interface ITurmaService : IServiceBase<Turma>
    {
        IEnumerable<Turma> GetTurma();
        void DesvinculaProfessor(Guid professorId);
    }
}