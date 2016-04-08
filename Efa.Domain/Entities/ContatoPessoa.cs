using System;

namespace Efa.Domain.Entities
{
    public class ContatoPessoa
    {
        public ContatoPessoa()
        {
            ContatoPessoaId = Guid.NewGuid();
        }

        public Guid ContatoPessoaId { get; set; }
        public Guid ContatoGrupoId { get; set; }
        public virtual ContatoGrupo ContatoGrupo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string TelefoneTrabalho { get; set; }
        public string Notas { get; set; }
    }
}