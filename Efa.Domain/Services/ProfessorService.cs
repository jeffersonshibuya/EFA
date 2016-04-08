using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;
using Efa.Domain.Validation.Alunos;
using Efa.Domain.Validation.Professores;
using Efa.Domain.ValueObjects;

namespace Efa.Domain.Services
{
    public class ProfessorService : ServiceBase<Professor>, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository): base(professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public ValidationResult AdicionarProfessor(Professor professor)
        {
            var resultado = new ValidationResult();

            if (!professor.IsValid())
            {
                resultado.AdicionarErro(professor.ResultadoValidacao);
                return resultado;
            }

            resultado = VerificaCpfJaCadastrado(professor);
            if (!resultado.IsValid)
            {
                resultado.AdicionarErro(professor.ResultadoValidacao);
                return resultado;
            }

            base.Add(professor);
            return resultado;
        }

        public ValidationResult AtualizarProfessor(Professor professor)
        {
            var resultado = new ValidationResult();

            if (!professor.IsValid())
            {
                resultado.AdicionarErro(professor.ResultadoValidacao);
                return resultado;
            }

            resultado = VerificaCpfJaCadastrado(professor);
            if (!resultado.IsValid)
            {
                resultado.AdicionarErro(professor.ResultadoValidacao);
                return resultado;
            }            

            base.Update(professor);
            return resultado;
        }

        public ValidationResult VerificaCpfJaCadastrado(Professor professor)
        {
            var fiscal = new ProfessorCPFNaoCadastrado(_professorRepository);

            var result = fiscal.Validar(professor);

            return result;
        }

    }
}
