using System;
using System.Data.Entity;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Efa.Infra.Data.Repository
{
    public class ContatoPessoaRepository : RepositoryBase<ContatoPessoa, EfaContext>, IContatoPessoaRepository
    {
        public IEnumerable<ContatoPessoa> GetContatos()
        {
            return base.DbSet.Include("ContatoGrupo").ToList();
        }

        public void RemoveFromGroup(Guid idGrupo)
        {
            IEnumerable<ContatoPessoa> contacts = base.Find(p => p.ContatoGrupoId == idGrupo).ToList();
            foreach (var p in contacts)
            {
                base.Remove(p);
            }
        }
    }
}