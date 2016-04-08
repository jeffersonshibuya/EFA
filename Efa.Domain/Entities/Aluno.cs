using System;
using System.Collections.Generic;
using Efa.Domain.Validation.Alunos;
using Efa.Domain.ValueObjects;

namespace Efa.Domain.Entities
{
    public class Aluno
    {
        public Aluno()
        {
            AlunoId = Guid.NewGuid();
        }
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }      
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Guid? TurmaId { get; set; }
        public virtual Turma Turma { get; set; }
        public Guid? NotasId { get; set; }
        public virtual Notas Notas { get; set; }
        public ValidationResult ResultadoValidacao { get; private set; }
        public DateTime DataCadastro { get; set; }

        public bool IsValid()
        {
            var fiscal = new AlunoEstaAptoParaCadastro();

            ResultadoValidacao = fiscal.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}