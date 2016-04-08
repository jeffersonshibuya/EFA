using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Specification;
using Efa.Domain.Validation.Documentos;

namespace Efa.Domain.Specification.Alunos
{
    public class AlunoPossuiEmailValido : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            //if (!string.IsNullOrEmpty(aluno.Email))
            //    return EmailValidation.Validar(aluno.Email);
            return true;
        }
    }
}
