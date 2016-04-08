using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Specification.Alunos;
using Efa.Domain.Validation.Base;

namespace Efa.Domain.Validation.Alunos
{
    public class AlunoCPFNaoCadastrado : FiscalBase<Aluno>
    {
        public AlunoCPFNaoCadastrado(IAlunoRepository alunoRepository)
        {
            var cpfNaoCadastrado = new CpfNaoCadastrado(alunoRepository);

            base.AdicionarRegra("CPFNaoCadastrado", new Regra<Aluno>(cpfNaoCadastrado, "O CPF informado já foi cadastrado"));
        }
    }
}