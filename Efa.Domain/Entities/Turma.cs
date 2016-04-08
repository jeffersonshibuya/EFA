using System;
using System.Collections.Generic;

namespace Efa.Domain.Entities
{
    public class Turma
    {
        public Turma()
        {
            TurmaId = Guid.NewGuid();
        }
        public Guid TurmaId { get; set; }        
        public string Livro { get; set; }
        public string TipoProva { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
        public string Dias { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual IEnumerable<Aluno> Alunos { get; set; }
        public Guid? ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
    }
}