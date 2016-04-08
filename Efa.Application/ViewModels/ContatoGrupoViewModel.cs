using System;
using System.ComponentModel.DataAnnotations;

namespace Efa.Application.ViewModels
{
    public class ContatoGrupoViewModel
    {
        public ContatoGrupoViewModel()
        {
            ContatoGrupoId = Guid.NewGuid();
        }
        [Key]
        public Guid ContatoGrupoId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Grupo")]
        [MaxLength(100, ErrorMessage = "Nome deve conter o máx. de 100 caracteres")]
        public string Nome { get; set; }
    }
}