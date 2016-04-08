using System;
using System.Collections.Generic;
using Efa.Domain.Entities;

namespace Efa.Domain.Interfaces.Repository
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        void AddAlunoTurma(IEnumerable<Aluno> alunos, Guid turmaId);
        IEnumerable<Aluno> GetAlunosNaoVinculados();
        void DesvinculaAlunos(Guid turmaId);
        IEnumerable<Aluno> GetAlunosTurma(Guid turmaId);
        IEnumerable<Aluno> GetAlunos();
    }
}