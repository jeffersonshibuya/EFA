using Efa.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Efa.Application.Interfaces
{
    public interface IContatoPessoaAppService : IDisposable
    {
        IEnumerable<ContatoPessoaViewModel> GetAll(int skip, int take);
        ContatoPessoaViewModel GetById(Guid id);
        void Update(ContatoPessoaViewModel contatoPessoaViewModel);
        void Remove(ContatoPessoaViewModel contatoPessoaViewModel);
        void Add(ContatoPessoaViewModel contatoPessoaViewModel);
        IEnumerable<ContatoPessoaViewModel> GetContatos();
        void RemoveFromGruoup(Guid idGrupo);
    }
}