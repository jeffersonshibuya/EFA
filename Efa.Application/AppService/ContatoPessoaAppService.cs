using AutoMapper;
using Efa.Application.Interfaces;
using Efa.Application.ViewModels;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Services;
using Efa.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace Efa.Application.AppService
{
    public class ContatoPessoaAppService : AppServiceBase<EfaContext>, IContatoPessoaAppService
    {
        private readonly IContatoPessoaService _contatoPessoaService;

        public ContatoPessoaAppService(IContatoPessoaService contatoPessoaService)
        {
            _contatoPessoaService = contatoPessoaService;
        }

        public IEnumerable<ContatoPessoaViewModel> GetAll(int skip, int take)
        {
            return Mapper.Map<IEnumerable<ContatoPessoa>, IEnumerable<ContatoPessoaViewModel>>(_contatoPessoaService.GetAll(skip, take));
        }

        public ContatoPessoaViewModel GetById(Guid id)
        {
            return Mapper.Map<ContatoPessoa, ContatoPessoaViewModel>(_contatoPessoaService.GetById(id));
        }

        public void Update(ContatoPessoaViewModel contatoGrupoViewModel)
        {
            var contatoGrupo = Mapper.Map<ContatoPessoaViewModel, ContatoPessoa>(contatoGrupoViewModel);

            BeginTransaction();
            _contatoPessoaService.Update(contatoGrupo);
            Commit();
        }

        public void Remove(ContatoPessoaViewModel contatoGrupoViewModel)
        {
            var contatoGrupo = Mapper.Map<ContatoPessoaViewModel, ContatoPessoa>(contatoGrupoViewModel);

            BeginTransaction();
            _contatoPessoaService.Remove(contatoGrupo);
            Commit();
        }

        public void Add(ContatoPessoaViewModel contatoGrupoViewModel)
        {
            var contatoGrupo = Mapper.Map<ContatoPessoaViewModel, ContatoPessoa>(contatoGrupoViewModel);

            BeginTransaction();
            _contatoPessoaService.Add(contatoGrupo);
            Commit();
        }

        public IEnumerable<ContatoPessoaViewModel> GetContatos()
        {
            return Mapper.Map<IEnumerable<ContatoPessoa>, IEnumerable<ContatoPessoaViewModel>>(_contatoPessoaService.GetContatos());
        }

        public void RemoveFromGruoup(Guid idGrupo)
        {
            BeginTransaction();
            _contatoPessoaService.RemoveFromGroup(idGrupo);
            Commit();
        }

        public void Dispose()
        {
            _contatoPessoaService.Dispose();
        }
    }
}