using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Specification;
using Efa.Domain.Validation.Documentos;

namespace Efa.Domain.Specification.Professores
{
    public class ProfessorPossuiCPFValido : ISpecification<Professor>
    {
        public bool IsSatisfiedBy(Professor professor)
        {
            if (!string.IsNullOrEmpty(professor.CPF))
                return CPFValidation.Validar(professor.CPF);
            return true;
        }
    }
}
