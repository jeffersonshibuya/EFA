using AutoMapper;
using Efa.Application.ViewModels;
using Efa.Domain.Entities;

namespace Efa.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Aluno, AlunoViewModel>();
            Mapper.CreateMap<Professor, ProfessorViewModel>();
            Mapper.CreateMap<Notas, NotasViewModel>();
            Mapper.CreateMap<Turma, TurmaViewModel>();
            Mapper.CreateMap<ContatoGrupo, ContatoGrupoViewModel>();
            Mapper.CreateMap<ContatoPessoa, ContatoPessoaViewModel>();
        } 
    }
}