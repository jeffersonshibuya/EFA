using System;
using System.Collections.Generic;
using Efa.Application.ViewModels;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Services;

namespace Efa.Application.Interfaces
{
    public interface IContatoGrupoAppService : IDisposable
    {
        IEnumerable<ContatoGrupoViewModel> GetAll(int skip, int take);
        ContatoGrupoViewModel GetById(Guid id);
        void Update(ContatoGrupoViewModel contatoGrupoViewModel);
        void Remove(ContatoGrupoViewModel contatoGrupoViewModel);
        void Add(ContatoGrupoViewModel contatoGrupoViewModel);
        IEnumerable<ContatoGrupoViewModel> GetGrupos();
    }
}