using System.Linq;
using Efa.Application.Interfaces;
using Efa.Application.ViewModels;
using Efa.Domain.Interfaces.Services;
using Efa.Infra.Data.Context;

namespace Efa.Application.AppService
{
    public class DashAppService : AppServiceBase<EfaContext>, IDashAppService
    {
        private readonly IAlunoService _alunoService; 
        private readonly ITurmaService _turmaService; 
        private readonly IProfessorService _professorService;
        private readonly IContatoPessoaAppService _contatoService;

        public DashAppService(IAlunoService alunoService, ITurmaService turmaService, IProfessorService professorService, IContatoPessoaAppService contatoService)
        {
            _alunoService = alunoService;
            _turmaService = turmaService;
            _professorService = professorService;
            _contatoService = contatoService;
        }

        public DashViewModel Dash()
        {
            BeginTransaction();
            var viewModel = new DashViewModel()
            {
                TotalAlunos = _alunoService.GetAll(0,5).Count(),
                TotalProfessores = _professorService.GetAll(0,5).Count(),
                TotalTurmas = _turmaService.GetAll(0,5).Count(),
                TotalContatos = _contatoService.GetAll(0,5).Count()
            };

            return viewModel;
        }

        public void Dispose()
        {
            _alunoService.Dispose();
            _professorService.Dispose();
            _turmaService.Dispose();
            _contatoService.Dispose();
        }
    }
}