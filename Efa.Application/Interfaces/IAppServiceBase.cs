using Efa.Infra.Data.Interfaces;

namespace Efa.Application.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void Commit();
    }
}