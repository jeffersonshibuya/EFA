using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Efa.Domain.Validation.Alunos;
using Efa.Domain.Validation.Professores;
using Efa.Domain.ValueObjects;

namespace Efa.Domain.Entities
{
    public class Professor
    {
        public Professor()
        {
            ProfessorId = Guid.NewGuid();
        }
        public Guid ProfessorId { get; set; }
        public string Nome { get; set; } 
        public string CPF { get; set; }
        public string Email { get; set; }  
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public ValidationResult ResultadoValidacao { get; private set; }

        public IEnumerable<Turma> Turmas { get; set; }

        public bool IsValid()
        {
            var fiscal = new ProfessorEstaAptoParaCadastro();

            ResultadoValidacao = fiscal.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}
