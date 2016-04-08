using System;

namespace Efa.Domain.Entities
{
    public class Notas
    {
        public Notas()
        {
            NotasId = Guid.NewGuid();
        }

        public Guid NotasId {get; set; }

        public int Quiz1 { get; set; }
        public int Quiz2 { get; set; }
        public int Quiz3 { get; set; }
        public int Quiz4 { get; set; }
        public int Quiz5 { get; set; }
        public int Quiz6 { get; set; }
        public int Quiz7 { get; set; }
        public int Quiz8 { get; set; }

        public int WrittenTest1 { get; set; }
        public int WrittenTest2 { get; set; }
        public int WrittenTest3 { get; set; }
        public int WrittenTest4 { get; set; }

        public int OralTest1 { get; set; }
        public int OralTest2 { get; set; }

        public int MediaQuiz { get; set; }
        public int MediaWrittenTest { get; set; }
        public int MediaOralTest { get; set; }
        public int MediaGeral { get; set; }

        public int RealizacaoTarefas { get; set; }
        public int ComportamentoDisciplina { get; set; }
        public int Desenvolvimento { get; set; }
        public int ResponsabilidadeInteresse { get; set; }
        public int Compreensao { get; set; }
        public int Assiduidade { get; set; }
        public int Gramatica { get; set; }
        public int Vocabulario { get; set; }

        //public Guid AlunoId { get; set; }

        //public virtual Aluno Aluno { get; set; }
    }
}