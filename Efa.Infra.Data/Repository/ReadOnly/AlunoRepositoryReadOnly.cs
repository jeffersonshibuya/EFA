using System.Collections.Generic;
using System.Data;
using Dapper;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;

namespace Efa.Infra.Data.Repository.ReadOnly
{
    public class AlunoRepositoryReadOnly : RepositoryBaseReadOnly, IAlunoRepositoryReadOnly
    {
        public IEnumerable<Aluno> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                var sql = @"Select * from aluno a " +
                    "left join turma t on a.turmaId = t.turmaId " + 
                    "left join professor p on p.professorId = t.professorId "+
                    "left join notas n on a.notasId = n.notasId ";  

                 cn.Open();

                var alunos = cn.Query<Aluno, Turma, Professor, Notas, Aluno>(
                    sql, (a, t, p, n) =>
                    {
                        a.Turma = t;
                        a.Notas = n;
                        //a.Turma.Professor = p;
                        return a;
                    }, splitOn: "AlunoId, TurmaId, ProfessorId, NotasId");

                return alunos;
            }
        }
    }
}