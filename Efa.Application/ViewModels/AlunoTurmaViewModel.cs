using System;
using System.Collections.Generic;

namespace Efa.Application.ViewModels
{
    public class AlunoTurmaViewModel
    {
        public IEnumerable<AlunoViewModel> Alunos { get; set; }

        public Guid TurmaId { get; set; }
    }
}