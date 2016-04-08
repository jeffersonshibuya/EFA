using System.Data.Entity;
using Efa.Infra.Data.Interfaces;

namespace Efa.Infra.Data.Context
{
    public class BaseContext : DbContext, IDbContext
    {
        public BaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}