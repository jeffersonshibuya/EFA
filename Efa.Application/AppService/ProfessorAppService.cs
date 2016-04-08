using System;
using System.Collections.Generic;
using AutoMapper;
using Efa.Application.Interfaces;
using Efa.Application.Validation;
using Efa.Application.ViewModels;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Services;
using Efa.Infra.Data.Context;

namespace Efa.Application.AppService
{
    public class ProfessorAppService : AppServiceBase<EfaContext>, IProfessorAppService
    {
        private readonly IProfessorService _professorService;

        public ProfessorAppService(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        public ValidationAppResult Add(ProfessorViewModel professorViewModel)
        {
            var professor = Mapper.Map<ProfessorViewModel, Professor>(professorViewModel);

            BeginTransaction();

            var result = _professorService.AdicionarProfessor(professor);

            if (!result.IsValid)
                return DomainToApplicationResult(result);
            _professorService.Add(professor);

            Commit();

            return DomainToApplicationResult(result);
        }

        public ProfessorViewModel GetById(Guid id)
        {
            return Mapper.Map<Professor, ProfessorViewModel>(_professorService.GetById(id));
        }

        public IEnumerable<ProfessorViewModel> GetAll(int skip, int take)
        {
            return Mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorViewModel>>(_professorService.GetAll(skip, take));
        }

        public ValidationAppResult Editar(ProfessorViewModel alunoViewModel)
        {
            var professor = Mapper.Map<ProfessorViewModel, Professor>(alunoViewModel);

            BeginTransaction();

            var result = _professorService.AtualizarProfessor(professor);

            if (!result.IsValid)
                return DomainToApplicationResult(result);
            _professorService.Update(professor);

            Commit();

            return DomainToApplicationResult(result);
        }

        public void Update(ProfessorViewModel alunoViewModel)
        {
            var professor = Mapper.Map<ProfessorViewModel, Professor>(alunoViewModel);

            BeginTransaction();
            _professorService.Update(professor);
            Commit();
        }

        public void Remove(ProfessorViewModel alunoViewModel)
        {
            var professor = Mapper.Map<ProfessorViewModel, Professor>(alunoViewModel);

            BeginTransaction();
            _professorService.Remove(professor);
            Commit();
        }

        public void Adicionar(ProfessorViewModel alunoViewModel)
        {
            var professor = Mapper.Map<ProfessorViewModel, Professor>(alunoViewModel);

            BeginTransaction();
            _professorService.Add(professor);
            Commit();
        }

        public void Dispose()
        {
            _professorService.Dispose();
        }    
    }
}