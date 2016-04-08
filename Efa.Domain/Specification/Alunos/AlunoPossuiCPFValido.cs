using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Specification;
using Efa.Domain.Validation.Documentos;

namespace Efa.Domain.Specification.Alunos
{
    public class AlunoPossuiCPFValido : ISpecification<Aluno>
    {

        public bool IsSatisfiedBy(Aluno aluno)
        {
            //if(!string.IsNullOrEmpty(aluno.CPF))
            //    return CPFValidation.Validar(aluno.CPF);
            return true;
        }
    }
}