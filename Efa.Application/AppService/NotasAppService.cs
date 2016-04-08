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
    public class NotasAppService : AppServiceBase<EfaContext>, INotasAppService
    {
        private readonly INotasService _notasService;

        public NotasAppService(INotasService notasService)
        {
            _notasService = notasService;
        }
      
        public NotasViewModel GetById(Guid id)
        {
            return Mapper.Map<Notas, NotasViewModel>(_notasService.GetById(id));
        }

        //public NotasViewModel GetByAluno(Guid id)
        //{
        //    return Mapper.Map<Notas, NotasViewModel>(_notasService.GetByAluno(id));
        //}

        public IEnumerable<NotasViewModel> GetAll(int skip, int take)
        {
            return Mapper.Map<IEnumerable<Notas>, IEnumerable<NotasViewModel>>(_notasService.GetAll(skip, take));
        }

        public void Add(NotasViewModel notasViewModel)
        {
            var notas = Mapper.Map<NotasViewModel, Notas>(notasViewModel);

            BeginTransaction();
            _notasService.Add(notas);
            Commit();
        }

      
        public void Update(NotasViewModel notasViewModel)
        {
            var notas = Mapper.Map<NotasViewModel, Notas>(notasViewModel);

            BeginTransaction();
            _notasService.Update(notas);
            Commit();
        }

        public void Remove(NotasViewModel notasViewModel)
        {
            var notas = Mapper.Map<NotasViewModel, Notas>(notasViewModel);

            BeginTransaction();
            _notasService.Remove(notas);
            Commit();
        }
       
        public void Dispose()
        {
            _notasService.Dispose();
        }    
    }
}