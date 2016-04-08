using Efa.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Efa.Application.ViewModels
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {
            AlunoId = Guid.NewGuid();
        }

        [Key]
        public Guid AlunoId { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Nome deve conter o máx. de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Nome deve conter no mín. 2 caracteres")]
        public string Nome { get; set; }       

        [MaxLength(10, ErrorMessage = "Telefone deve conter o máx. de 10 caracteres")]
        public string Telefone { get; set; }

        [MaxLength(10, ErrorMessage = "Celular deve conter o máx. de 10 caracteres")]
        public string Celular { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public Guid? TurmaId { get; set; }

        public virtual Turma Turma { get; set; }

        public Guid? NotasId { get; set; }
        public virtual Notas Notas { get; set; }
    }
}