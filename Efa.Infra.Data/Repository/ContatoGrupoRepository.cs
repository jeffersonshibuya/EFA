using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Efa.Infra.Data.Repository
{
    public class ContatoGrupoRepository : RepositoryBase<ContatoGrupo, EfaContext>, IContatoGrupoRepository
    {
        public IEnumerable<ContatoGrupo> GetGrupos()
        {
            return base.DbSet.ToList();
        }
    }
}