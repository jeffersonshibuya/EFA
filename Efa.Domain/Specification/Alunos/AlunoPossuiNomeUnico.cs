using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Specification;
using System.Linq;

namespace Efa.Domain.Specification.Alunos
{
    public class AlunoPossuiNomeUnico : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoPossuiNomeUnico(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            var alunoBase = _alunoRepository.GetById(aluno.AlunoId);
            // Se forem iguais estou editando sem alterar o cpf do mesmo
            if (alunoBase != null && alunoBase.Nome == aluno.Nome)
                return true;
            return !_alunoRepository.Find(a => a.Nome == aluno.Nome).Any();
        }
    }
}
