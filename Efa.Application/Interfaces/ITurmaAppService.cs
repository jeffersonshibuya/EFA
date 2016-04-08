using Efa.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Efa.Application.Interfaces
{
    public interface ITurmaAppService   
    {
        TurmaViewModel GetById(Guid id);
        IEnumerable<TurmaViewModel> GetAll(int skip, int take);
        void Update(TurmaViewModel turmaViewModel);
        void Remove(TurmaViewModel turmaViewModel);
        void Add(TurmaViewModel turmaViewModel);
        IEnumerable<TurmaViewModel> GetTurma();

        void DesvinculaProfessor(Guid professorId);

    }
}