using System;
using System.ComponentModel.DataAnnotations;

namespace Efa.Application.ViewModels
{
    public class NotasViewModel
    {
        public NotasViewModel()
        {
            NotasId = Guid.NewGuid();
        }

        [Key]
        public Guid NotasId { get; set; }

        //QUIZ TEST  
        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz1 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz2 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz3 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz4 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz5 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz6 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz7 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Quiz 1 acima do permitido (50)")]
        public int Quiz8 { get; set; }

        //WRITTEN TEST
        [Range(0, 100, ErrorMessage = "Nota do Written Test 1 acima do permitido (100)")]
        public int WrittenTest1 { get; set; }

        [Range(0, 100, ErrorMessage = "Nota do Written Test 2 acima do permitido (100)")]
        public int WrittenTest2 { get; set; }
        
        [Range(0, 100, ErrorMessage = "Nota do Written Test 3 acima do permitido (100)")]
        public int WrittenTest3 { get; set; }
        
        [Range(0, 100, ErrorMessage = "Nota do Written Test 4 acima do permitido (100)")]
        public int WrittenTest4 { get; set; }

        //ORAL TEST
        [Range(0, 50, ErrorMessage = "Nota do Oral Test 1 acima do permitido (50)")]
        public int OralTest1 { get; set; }

        [Range(0, 50, ErrorMessage = "Nota do Oral Test 2 acima do permitido (50)")]
        public int OralTest2 { get; set; }

        //Medias
        [Range(0, 100, ErrorMessage = "Media Quiz acima do permitido")]
        public int MediaQuiz { get; set; }

        [Range(0, 100, ErrorMessage = "Media Oral Test acima do permitido")]
        public int MediaOralTest { get; set; }

        [Range(0, 100, ErrorMessage = "Media Written Test acima do permitido")]
        public int MediaWrittenTest { get; set; }

        [Range(0, 100, ErrorMessage = "Media Geral acima do permitido")]
        public int MediaGeral { get; set; }


        //Avaliacao do Professor
        [Range(0, 100, ErrorMessage = "Realização de Tarefas acima do permitido")]
        public int RealizacaoTarefas { get; set; }

        [Range(0, 100, ErrorMessage = "Comportamento e Disciplina acima do permitido")]
        public int ComportamentoDisciplina { get; set; }

        [Range(0, 100, ErrorMessage = "Desenvolvimento acima do permitido")]
        public int Desenvolvimento { get; set; }

        [Range(0, 100, ErrorMessage = "Responsabilidade e Interesse acima do permitido")]
        public int ResponsabilidadeInteresse { get; set; }


        [Range(0, 100, ErrorMessage = "Compreensao acima do permitido")]
        public int Compreensao { get; set; }

        [Range(0, 100, ErrorMessage = "Assiduidade acima do permitido")]
        public int Assiduidade { get; set; }

        [Range(0, 100, ErrorMessage = "Gramatica acima do permitido")]
        public int Gramatica { get; set; }

        [Range(0, 100, ErrorMessage = "Vocabulario acima do permitido")]
        public int Vocabulario { get; set; }



        [Required(ErrorMessage = "Aluno não foi selecionado")]
        public Guid AlunoId { get; set; }

    }
}