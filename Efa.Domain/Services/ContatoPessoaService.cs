using System;
using System.Collections.Generic;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;

namespace Efa.Domain.Services
{
    public class ContatoPessoaService : ServiceBase<ContatoPessoa>, IContatoPessoaService
    {
        private readonly IContatoPessoaRepository _contatoPessoaRepository;

        public ContatoPessoaService(IContatoPessoaRepository contatoPessoaRepository)
            : base(contatoPessoaRepository)
        {
            _contatoPessoaRepository = contatoPessoaRepository;
        }

        public IEnumerable<ContatoPessoa> GetContatos()
        {
            return _contatoPessoaRepository.GetContatos();
        }

        public void RemoveFromGroup(Guid idGrupo)
        {
            _contatoPessoaRepository.RemoveFromGroup(idGrupo);
        }
    }
}