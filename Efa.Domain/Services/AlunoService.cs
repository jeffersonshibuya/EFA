using System;
using System.Collections.Generic;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;
using Efa.Domain.Validation.Alunos;
using Efa.Domain.ValueObjects;

namespace Efa.Domain.Services
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoRepositoryReadOnly _alunoReadOnlyRepository;

        public AlunoService(IAlunoRepository alunoRepository, IAlunoRepositoryReadOnly alunoReadOnlyRepository) : base(alunoRepository)
        {
            _alunoRepository = alunoRepository;
            _alunoReadOnlyRepository = alunoReadOnlyRepository;
        }

        public void AddAlunoTurma(IEnumerable<Aluno> alunos, Guid turmaId)
        {
            _alunoRepository.AddAlunoTurma(alunos, turmaId);
        }

        public IEnumerable<Aluno> GetAlunosNaoVinculados()
        {
            return _alunoRepository.GetAlunosNaoVinculados();
        }

        public void DesvinculaAlunos(Guid turmaId)
        {
            _alunoRepository.DesvinculaAlunos(turmaId);
        }

        public IEnumerable<Aluno> GetAlunosTurma(Guid turmaId)
        {
            return _alunoRepository.GetAlunosTurma(turmaId);
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            //return _alunoRepository.GetAlunos();
            return _alunoReadOnlyRepository.GetAll();
        }

        public ValidationResult AdicionarAluno(Aluno aluno)
        {
            var resultado = new ValidationResult();

            if (!aluno.IsValid())
            {
                resultado.AdicionarErro(aluno.ResultadoValidacao);
                return resultado;
            }

            //resultado = VerificaCpfJaCadastrado(aluno);
            //if (!resultado.IsValid)
            //{
            //    resultado.AdicionarErro(aluno.ResultadoValidacao);
            //    return resultado;
            //}

            resultado = VerificaNomeUnico(aluno);
            if (!resultado.IsValid)
            {
                resultado.AdicionarErro(aluno.ResultadoValidacao);
                return resultado;
            }

            base.Add(aluno);
            return resultado;
        }

        public ValidationResult AtualizarAluno(Aluno aluno)
        {
            var resultado = new ValidationResult();

            if (!aluno.IsValid())
            {
                resultado.AdicionarErro(aluno.ResultadoValidacao);
                return resultado;
            }

            //resultado = VerificaCpfJaCadastrado(aluno);
            //if (!resultado.IsValid)
            //{
            //    resultado.AdicionarErro(aluno.ResultadoValidacao);
            //    return resultado;
            //}
            
            resultado = VerificaNomeUnico(aluno);
            if (!resultado.IsValid)
            {
                resultado.AdicionarErro(aluno.ResultadoValidacao);
                return resultado;
            }

            base.Update(aluno);
            return resultado;
        }

        public ValidationResult VerificaCpfJaCadastrado(Aluno aluno)
        {
            var fiscal = new AlunoCPFNaoCadastrado(_alunoRepository);

            var result = fiscal.Validar(aluno);

            return result;
        }

        public ValidationResult VerificaNomeUnico(Aluno aluno)
        {
            var fiscal = new AlunoNomeUnico(_alunoRepository);

            var result = fiscal.Validar(aluno);

            return result;
        }

        
    }
}