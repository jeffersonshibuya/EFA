using System;
using System.Collections.Generic;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;

namespace Efa.Domain.Services
{
    public class TurmaService : ServiceBase<Turma>, ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository) : base(turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public IEnumerable<Turma> GetTurma()
        {
            return _turmaRepository.GetTurma();
        }

        public void DesvinculaProfessor(Guid professorId)
        {
            _turmaRepository.DesvinculaProfessor(professorId);
        }
    }
}