using System.Data.Entity.ModelConfiguration;
using Efa.Domain.Entities;

namespace Efa.Infra.Data.EntityConfig
{
    public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            ToTable("Aluno");

            HasKey(a => a.AlunoId).HasOptional(a => a.Notas);

            Property(a => a.Nome).IsRequired();

            Property(a => a.NotasId).IsOptional();

            Property(a => a.TurmaId).IsOptional();

            Property(a => a.Telefone).HasMaxLength(10);

            Property(a => a.Celular).HasMaxLength(10);

            Ignore(a => a.ResultadoValidacao);

            HasOptional(a => a.Turma)
                .WithMany()
                .HasForeignKey(a => a.TurmaId);
        }
    }
}