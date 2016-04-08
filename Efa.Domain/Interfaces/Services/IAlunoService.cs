using System;
using System.Collections.Generic;
using Efa.Domain.Entities;
using Efa.Domain.ValueObjects;

namespace Efa.Domain.Interfaces.Services
{
    public interface IAlunoService : IServiceBase<Aluno>
    {
        ValidationResult AdicionarAluno(Aluno aluno);

        ValidationResult AtualizarAluno(Aluno aluno);

        void AddAlunoTurma(IEnumerable<Aluno> alunos, Guid turmaId);

        IEnumerable<Aluno> GetAlunosNaoVinculados();
        void DesvinculaAlunos(Guid turmaId);

        IEnumerable<Aluno> GetAlunosTurma(Guid turmaId);
        IEnumerable<Aluno> GetAlunos();
    }
}