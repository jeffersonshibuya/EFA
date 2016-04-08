using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Specification;
using Efa.Domain.Validation.Documentos;

namespace Efa.Domain.Specification.Professores
{
    public class ProfessorPossuiEmailValido : ISpecification<Professor>
    {
        public bool IsSatisfiedBy(Professor professor)
        {
            if (!string.IsNullOrEmpty(professor.Email))
                return EmailValidation.Validar(professor.Email);
            return true;
        }
    }
}
