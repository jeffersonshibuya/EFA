using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Infra.Data.Context;

namespace Efa.Infra.Data.Repository
{
    public class TurmaRepository : RepositoryBase<Turma, EfaContext>, ITurmaRepository
    {
        public List<Turma> GetTurma()
        {
            return base.DbSet.Include("Professor").ToList();
        }

        public void DesvinculaProfessor(Guid professorId)
        {
            foreach (var turma in DbSet.ToList())
            {
                if (turma.ProfessorId == professorId)
                {
                    turma.ProfessorId = null;
                    base.Update(turma);
                }
            }
        }
    }
}