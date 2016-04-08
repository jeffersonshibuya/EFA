using System;
using System.Collections.Generic;
using Efa.Domain.Entities;

namespace Efa.Domain.Interfaces.Repository
{
    public interface ITurmaRepository : IRepositoryBase<Turma>
    {
        List<Turma> GetTurma();
        void DesvinculaProfessor(Guid professorId);
    }
}