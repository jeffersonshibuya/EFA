using System.ComponentModel.DataAnnotations;

namespace Efa.Application.ViewModels
{
    public class TesteViewModel
    {
        [Required(ErrorMessage = "Esqueceu seu proprio nome? aff, se mata!")]
        public string Nome { get; set; }

        [Range(0, 100, ErrorMessage = "Você não é Matusalém, pare de mentir seu safado!")]
        public int Idade { get; set; }
    }
}
