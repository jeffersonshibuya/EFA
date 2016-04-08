using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Infra.Data.Context;

namespace Efa.Infra.Data.Repository
{
    public class AlunoRepository : RepositoryBase<Aluno, EfaContext>, IAlunoRepository
    {
        public void AddAlunoTurma(IEnumerable<Aluno> alunos, Guid turmaId)
        {
            foreach (var aluno  in alunos)
            {
                aluno.TurmaId = turmaId;
                base.Update(aluno);
            }
        }

        public IEnumerable<Aluno> GetAlunosNaoVinculados()
        {
            return base.Find(a => a.TurmaId == null).ToList();
        }

        public void DesvinculaAlunos(Guid turmaId)
        {

            foreach (var aluno in base.Find(a => a.TurmaId == turmaId).ToList())
            {
                aluno.TurmaId = null;
                base.Update(aluno);
            }
        }

        public IEnumerable<Aluno> GetAlunosTurma(Guid turmaId)
        {
            return base.DbSet.Include("Turma.Professor").Include("Notas").Where(a => a.TurmaId == turmaId).ToList();
            //return base.Find(a => a.TurmaId == turmaId).ToList();
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            return base.DbSet.Include("Turma.Professor").Include("Notas").ToList();
        }
    }
}