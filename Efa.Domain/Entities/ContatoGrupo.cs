using System;
using System.Collections.Generic;

namespace Efa.Domain.Entities
{
    public class ContatoGrupo
    {
        public ContatoGrupo()
        {
            ContatoGrupoId = Guid.NewGuid();
        }

        public Guid ContatoGrupoId { get; set; }
        public string Nome { get; set; }
    }
}
