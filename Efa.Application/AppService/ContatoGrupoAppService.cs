using System;
using System.Collections.Generic;
using AutoMapper;
using Efa.Application.Interfaces;
using Efa.Application.ViewModels;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Services;
using Efa.Infra.Data.Context;

namespace Efa.Application.AppService
{
    public class ContatoGrupoAppService : AppServiceBase<EfaContext>, IContatoGrupoAppService
    {
        private readonly IContatoGrupoService _contatoGrupoService;

        public ContatoGrupoAppService(IContatoGrupoService contatoGrupoService)
        {
            _contatoGrupoService = contatoGrupoService;
        }

        public IEnumerable<ContatoGrupoViewModel> GetAll(int skip, int take)
        {
            return Mapper.Map<IEnumerable<ContatoGrupo>, IEnumerable<ContatoGrupoViewModel>>(_contatoGrupoService.GetAll(skip, take));
        }

        public ContatoGrupoViewModel GetById(Guid id)
        {
            return Mapper.Map<ContatoGrupo, ContatoGrupoViewModel>(_contatoGrupoService.GetById(id));
        }

        public void Update(ContatoGrupoViewModel contatoGrupoViewModel)
        {
            var contatoGrupo = Mapper.Map<ContatoGrupoViewModel, ContatoGrupo>(contatoGrupoViewModel);

            BeginTransaction();
            _contatoGrupoService.Update(contatoGrupo);
            Commit();
        }

        public void Remove(ContatoGrupoViewModel contatoGrupoViewModel)
        {
            var contatoGrupo = Mapper.Map<ContatoGrupoViewModel, ContatoGrupo>(contatoGrupoViewModel);

            BeginTransaction();
            _contatoGrupoService.Remove(contatoGrupo);
            Commit();
        }

        public void Add(ContatoGrupoViewModel contatoGrupoViewModel)
        {
            var contatoGrupo = Mapper.Map<ContatoGrupoViewModel, ContatoGrupo>(contatoGrupoViewModel);

            BeginTransaction();
            _contatoGrupoService.Add(contatoGrupo);
            Commit();
        }

        public IEnumerable<ContatoGrupoViewModel> GetGrupos()
        {
            return Mapper.Map<IEnumerable<ContatoGrupo>, IEnumerable<ContatoGrupoViewModel>>(_contatoGrupoService.GetGrupos());
        }

        public void Dispose()
        {
            _contatoGrupoService.Dispose();
        }    
    }
}