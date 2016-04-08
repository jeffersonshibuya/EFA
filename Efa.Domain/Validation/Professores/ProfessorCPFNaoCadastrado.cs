using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Specification.Professores;
using Efa.Domain.Validation.Base;

namespace Efa.Domain.Validation.Professores
{
    public class ProfessorCPFNaoCadastrado : FiscalBase<Professor>
    {
        public ProfessorCPFNaoCadastrado(IProfessorRepository professorRepository)
        {
            var cpfNaoCadastrado = new CpfNaoCadastrado(professorRepository);

            base.AdicionarRegra("CPFNaoCadastrado", new Regra<Professor>(cpfNaoCadastrado, "O CPF informado já foi cadastrado"));
        }
    }
}