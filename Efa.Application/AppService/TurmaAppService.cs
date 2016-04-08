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
    public class TurmaAppService : AppServiceBase<EfaContext>, ITurmaAppService
    {
        private readonly ITurmaService _turmaService;

        public TurmaAppService(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        public IEnumerable<TurmaViewModel> GetTurma()
        {
            return Mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaViewModel>>(_turmaService.GetTurma());
        }

        public void DesvinculaProfessor(Guid professorId)
        {
            _turmaService.DesvinculaProfessor(professorId);
        }

        public TurmaViewModel GetById(Guid id)
        {
            return Mapper.Map<Turma, TurmaViewModel>(_turmaService.GetById(id));
        }

        public IEnumerable<TurmaViewModel> GetAll(int skip, int take)
        {
            return Mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaViewModel>>(_turmaService.GetAll(skip, take));
        }

        public void Add(TurmaViewModel turmaViewModel)
        {
            var turma = Mapper.Map<TurmaViewModel, Turma>(turmaViewModel);

            BeginTransaction();
            _turmaService.Add(turma);
            Commit();
        }


        public void Update(TurmaViewModel turmaViewModel)
        {
            var turma = Mapper.Map<TurmaViewModel, Turma>(turmaViewModel);

            BeginTransaction();
            _turmaService.Update(turma);
            Commit();
        }

        public void Remove(TurmaViewModel turmaViewModel)
        {
            var turma = Mapper.Map<TurmaViewModel, Turma>(turmaViewModel);

            BeginTransaction();
            _turmaService.Remove(turma);
            Commit();
        }

        public void Dispose()
        {
            _turmaService.Dispose();
        }    
    }
}