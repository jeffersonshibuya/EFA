using AutoMapper;
using Efa.Application.ViewModels;
using Efa.Domain.Entities;

namespace Efa.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AlunoViewModel, Aluno>();
            Mapper.CreateMap<ProfessorViewModel, Professor>();
            Mapper.CreateMap<NotasViewModel, Notas>();
            Mapper.CreateMap<TurmaViewModel, Turma>();
            Mapper.CreateMap<ContatoGrupoViewModel, ContatoGrupo>();
            Mapper.CreateMap<ContatoPessoaViewModel, ContatoPessoa>();
        } 
    }
}