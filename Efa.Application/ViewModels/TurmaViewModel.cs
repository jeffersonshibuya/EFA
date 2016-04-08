using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Efa.Domain.Entities;

namespace Efa.Application.ViewModels
{
    public class TurmaViewModel
    {
        public TurmaViewModel()
        {
            TurmaId = Guid.NewGuid();
        }

        [Key]
        public Guid TurmaId { get; set; }
        public string Livro { get; set; }
        public string TipoProva { get; set; }
        public Guid? ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
        public string Dias { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Aluno> Alunos { get; set; }

    }
}