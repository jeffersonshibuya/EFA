using Efa.Domain.Entities;
using Efa.Domain.Specification.Professores;
using Efa.Domain.Validation.Base;

namespace Efa.Domain.Validation.Professores
{
    public class ProfessorEstaAptoParaCadastro : FiscalBase<Professor>
    {

        public ProfessorEstaAptoParaCadastro()
        {
            var professorCPFValido = new ProfessorPossuiCPFValido();
            var professorEmailValido = new ProfessorPossuiEmailValido();

            base.AdicionarRegra("ProfessorCPFValido", new Regra<Professor>(professorCPFValido, "CPF informado é inválido"));
            base.AdicionarRegra("ProfessorEmailValido", new Regra<Professor>(professorEmailValido, "E-mail inválido"));
        }
        
    }
}
