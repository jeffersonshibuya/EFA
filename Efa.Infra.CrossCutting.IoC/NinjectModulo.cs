using Efa.Application.AppService;
using Efa.Application.Interfaces;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;
using Efa.Domain.Services;
using Efa.Infra.Data.Context;
using Efa.Infra.Data.Interfaces;
using Efa.Infra.Data.Repository;
using Efa.Infra.Data.Repository.ReadOnly;
using Efa.Infra.Data.UoW;
using Ninject.Modules;

namespace Efa.Infra.CrossCutting.IoC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            //APP
            Bind<IAlunoAppService>().To<AlunoAppService>();
            Bind<IProfessorAppService>().To<ProfessorAppService>();
            Bind<INotasAppService>().To<NotasAppService>();
            Bind<ITurmaAppService>().To<TurmaAppService>();
            Bind<IContatoGrupoAppService>().To<ContatoGrupoAppService>();
            Bind<IContatoPessoaAppService>().To<ContatoPessoaAppService>();
            Bind<IDashAppService>().To<DashAppService>();

            //Service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IAlunoService>().To<AlunoService>();
            Bind<IProfessorService>().To<ProfessorService>();
            Bind<INotasService>().To<NotasService>();
            Bind<ITurmaService>().To<TurmaService>();
            Bind<IContatoGrupoService>().To<ContatoGrupoService>();
            Bind<IContatoPessoaService>().To<ContatoPessoaService>();

            //Repositories
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
            Bind<IAlunoRepository>().To<AlunoRepository>();
            Bind<IProfessorRepository>().To<ProfessorRepository>();
            Bind<INotasRepository>().To<NotasRepository>();
            Bind<ITurmaRepository>().To<TurmaRepository>();
            Bind<IContatoGrupoRepository>().To<ContatoGrupoRepository>();
            Bind<IContatoPessoaRepository>().To<ContatoPessoaRepository>();

            //Repositories readOnly
            Bind<IAlunoRepositoryReadOnly>().To<AlunoRepositoryReadOnly>();
            //Bind<IEnderecoRepositoryReadOnly>().To<EnderecoRepositoryReadOnly>();

            //DataConfig
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<EfaContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));
        }
    }
}