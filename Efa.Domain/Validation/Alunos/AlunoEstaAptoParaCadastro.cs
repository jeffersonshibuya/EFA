using Efa.Domain.Entities;
using Efa.Domain.Specification.Alunos;
using Efa.Domain.Validation.Base;

namespace Efa.Domain.Validation.Alunos
{
    public class AlunoEstaAptoParaCadastro : FiscalBase<Aluno>
    {
        public AlunoEstaAptoParaCadastro()
        {
            //var alunoCPFValido = new AlunoPossuiCPFValido();
            //var alunoEmailValido = new AlunoPossuiEmailValido();

            //base.AdicionarRegra("AlunoCPFValido", new Regra<Aluno>(alunoCPFValido, "CPF informado é inválido"));
            //base.AdicionarRegra("AlunoEmailValido", new Regra<Aluno>(alunoEmailValido, "E-mail inválido"));
        }
    }
}