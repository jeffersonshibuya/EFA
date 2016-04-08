using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Specification.Alunos;
using Efa.Domain.Validation.Base;

namespace Efa.Domain.Validation.Alunos
{
    public class AlunoNomeUnico : FiscalBase<Aluno>
    {
        public AlunoNomeUnico(IAlunoRepository alunoRepository)
        {
            var alunoNomeUnico = new AlunoPossuiNomeUnico(alunoRepository);

            base.AdicionarRegra("CPFNaoCadastrado", new Regra<Aluno>(alunoNomeUnico, "Já existe aluno com esse nome cadastrado"));
        }
    }
}
