using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Efa.Domain.Entities;

namespace Efa.Application.ViewModels
{
    public class ContatoPessoaViewModel
    {
        public ContatoPessoaViewModel()
        {
            ContatoPessoaId = Guid.NewGuid();
        }
        [Key]
        public Guid ContatoPessoaId { get; set; }

        [MaxLength(100, ErrorMessage = "Nome deve conter o máx. de 100 caracteres")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "Sobrenome deve conter o máx. de 100 caracteres")]
        public string Sobrenome { get; set; }

        [MaxLength(100, ErrorMessage = "Telefone deve conter o máx. de 100 caracteres")]
        public string Telefone { get; set; }

        [MaxLength(100, ErrorMessage = "Celular deve conter o máx. de 100 caracteres")]
        public string Celular { get; set; }

        [MaxLength(100, ErrorMessage = "Telefone Trabalho deve conter o máx. de 100 caracteres")]
        public string TelefoneTrabalho { get; set; }

        [MaxLength(100, ErrorMessage = "Notas deve conter o máx. de 100 caracteres")]
        public string Notas { get; set; }

        public Guid ContatoGrupoId { get; set; }
        public virtual ContatoGrupo ContatoGrupo { get; set; }
    }
}