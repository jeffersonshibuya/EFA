using System;
using System.Linq;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Infra.Data.Context;

namespace Efa.Infra.Data.Repository
{
    public class NotasRepository : RepositoryBase<Notas, EfaContext>, INotasRepository
    {
        //public Notas GetByAluno(Guid id)
        //{
        //    return base.Find(c => c.AlunoId == id).FirstOrDefault();
        //}
    }
}