using Efa.Application.Validation;
using Efa.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Efa.Application.Interfaces
{
    public interface IAlunoAppService : IDisposable
    {
        ValidationAppResult Add(AlunoViewModel alunoViewModel);
        AlunoViewModel GetById(Guid id);
        IEnumerable<AlunoViewModel> GetAll(int skip, int take);
        IEnumerable<AlunoViewModel> GetAlunos();
        IEnumerable<AlunoViewModel> GetAlunosNaoVinculados();
        IEnumerable<AlunoViewModel> GetAlunosTurma(Guid turmaId); 
        void DesvinculaAlunos(Guid turmaId);
        ValidationAppResult Editar(AlunoViewModel alunoViewModel);
        void Update(AlunoViewModel alunoViewModel);
        void Remove(AlunoViewModel alunoViewModel);
        void Adicionar(AlunoViewModel alunoViewModel);
        void AddAlunoTurma(IEnumerable<AlunoViewModel> alunos, Guid turmaId);
    }
}