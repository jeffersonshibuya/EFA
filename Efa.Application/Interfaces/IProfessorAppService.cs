using Efa.Application.Validation;
using Efa.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Efa.Application.Interfaces
{
    public interface IProfessorAppService : IDisposable
    {
        ValidationAppResult Add(ProfessorViewModel professorViewModel);
        ProfessorViewModel GetById(Guid id);
        IEnumerable<ProfessorViewModel> GetAll(int skip, int take);
        ValidationAppResult Editar(ProfessorViewModel professorViewModel);
        void Update(ProfessorViewModel professorViewModel);
        void Remove(ProfessorViewModel professorViewModel);
        void Adicionar(ProfessorViewModel professorViewModel); 
    }
}