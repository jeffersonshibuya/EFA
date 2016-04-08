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
    public class AlunoAppService : AppServiceBase<EfaContext>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public ValidationAppResult Add(AlunoViewModel alunoViewModel)
        {
            var aluno = Mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);

            BeginTransaction();

            var result = _alunoService.AdicionarAluno(aluno);

            if (!result.IsValid)
                return DomainToApplicationResult(result);
            _alunoService.Add(aluno);

            Commit();

            return DomainToApplicationResult(result);
        }

        public void AddAlunoTurma(IEnumerable<AlunoViewModel> alunos, Guid turmaId)
        {
            BeginTransaction();

            IEnumerable<Aluno> alunosList = Mapper.Map<IEnumerable<AlunoViewModel>, IEnumerable<Aluno>>(alunos);
            _alunoService.AddAlunoTurma(alunosList, turmaId);

            Commit();
        }

        public AlunoViewModel GetById(Guid id)
        {
            return Mapper.Map<Aluno, AlunoViewModel>(_alunoService.GetById(id));
        }

        public IEnumerable<AlunoViewModel> GetAll(int skip, int take)
        {
            return Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(_alunoService.GetAll(skip, take));
        }

        public IEnumerable<AlunoViewModel> GetAlunos()
        {
            return Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(_alunoService.GetAlunos());
        }

        public IEnumerable<AlunoViewModel> GetAlunosNaoVinculados()
        {
            return Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(_alunoService.GetAlunosNaoVinculados());
        }

        public IEnumerable<AlunoViewModel> GetAlunosTurma(Guid turmaId)
        {
            return Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(_alunoService.GetAlunosTurma(turmaId));
        }

        public ValidationAppResult Editar(AlunoViewModel alunoViewModel)
        {
            var aluno = Mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);

            BeginTransaction();

            var result = _alunoService.AtualizarAluno(aluno);

            if (!result.IsValid)
                return DomainToApplicationResult(result);
            _alunoService.Update(aluno);

            Commit();

            return DomainToApplicationResult(result);
        }

        public void Update(AlunoViewModel alunoViewModel)
        {
            var aluno = Mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);

            BeginTransaction();
            _alunoService.Update(aluno);
            Commit();
        }

        public void DesvinculaAlunos(Guid turmaId)
        {
            BeginTransaction();
            _alunoService.DesvinculaAlunos(turmaId);
            Commit();
        }

        public void Remove(AlunoViewModel alunoViewModel)
        {
            var aluno = Mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);

            BeginTransaction();
            _alunoService.Remove(aluno);
            Commit();
        }

        public void Adicionar(AlunoViewModel alunoViewModel)
        {
            var aluno = Mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);

            BeginTransaction();
            _alunoService.Add(aluno);
            Commit();
        }

        public void Dispose()
        {
            _alunoService.Dispose();
        }
    }
}