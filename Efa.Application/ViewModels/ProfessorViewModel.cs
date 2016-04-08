using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Efa.Domain.Entities;

namespace Efa.Application.ViewModels
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel()
        {
            ProfessorId = Guid.NewGuid();
        }

        [Key]
        public Guid ProfessorId { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Nome deve conter o máx. de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Nome deve conter no mín. 2 caracteres")]
        public string Nome { get; set; }

        [MaxLength(14, ErrorMessage = "CPF deve conter o máx. de 14 caracteres")]
        public string CPF { get; set; }

        [MaxLength(120, ErrorMessage = "Email deve conter o máx. de 120 caracteres")]
        public string Email { get; set; } 

        [MaxLength(10, ErrorMessage = "Telefone deve conter o máx. de 10 caracteres")]
        public string Telefone { get; set; }

        [MaxLength(10, ErrorMessage = "Celular deve conter o máx. de 10 caracteres")]
        public string Celular { get; set; }

        public virtual List<Turma> Turmas { get; set; }
    }
}