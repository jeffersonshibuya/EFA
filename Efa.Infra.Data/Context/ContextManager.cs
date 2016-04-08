using System.Web;
using Efa.Infra.Data.Interfaces;

namespace Efa.Infra.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        //OneContextPerRequest
        private const string ContextKey = "ContextManager.Context";

        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
                HttpContext.Current.Items[ContextKey] = new TContext();

            return (IDbContext)HttpContext.Current.Items[ContextKey];
        }
    }
}