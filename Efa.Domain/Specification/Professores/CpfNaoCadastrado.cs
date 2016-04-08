using System.Linq;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Specification;

namespace Efa.Domain.Specification.Professores
{
    public class CpfNaoCadastrado : ISpecification<Professor>
    {
        private readonly IProfessorRepository _professorRepository;

        public CpfNaoCadastrado(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public bool IsSatisfiedBy(Professor professor)
        {
            var professorBase = _professorRepository.GetById(professor.ProfessorId);

            if (!string.IsNullOrEmpty(professor.CPF))
            {
                // Se forem iguais estou editando sem alterar o cpf do mesmo
                if (professorBase != null && professorBase.CPF == professor.CPF)
                    return true;
                return !_professorRepository.Find(p => p.CPF == professor.CPF).Any();
            }
                
            return true;
        }
    }
}