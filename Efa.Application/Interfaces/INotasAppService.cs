using Efa.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Efa.Application.Interfaces
{
    public interface INotasAppService : IDisposable
    {
        NotasViewModel GetById(Guid id);
        IEnumerable<NotasViewModel> GetAll(int skip, int take);
        void Update(NotasViewModel notasViewModel);
        void Remove(NotasViewModel notasViewModel);
        void Add(NotasViewModel notasViewModel);
        //NotasViewModel GetByAluno(Guid id);
    }
}