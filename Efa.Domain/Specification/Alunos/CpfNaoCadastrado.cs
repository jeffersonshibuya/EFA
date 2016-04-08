using System.Linq;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Specification;

namespace Efa.Domain.Specification.Alunos
{
    public class CpfNaoCadastrado : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public CpfNaoCadastrado(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            //Cadastro            
            //var alunoBase = _alunoRepository.GetById(aluno.AlunoId);
            
            //if (!string.IsNullOrEmpty(aluno.CPF))
            //{
            //    // Se forem iguais estou editando sem alterar o cpf do mesmo
            //    if (alunoBase != null && alunoBase.CPF == aluno.CPF)
            //        return true;
            //    return !_alunoRepository.Find(a => a.CPF == aluno.CPF).Any();
            //}
                
            return true;
        }
    }
}