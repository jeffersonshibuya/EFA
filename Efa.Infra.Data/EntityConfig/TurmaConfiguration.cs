using System.Data.Entity.ModelConfiguration;
using Efa.Domain.Entities;

namespace Efa.Infra.Data.EntityConfig
{
    public class TurmaConfiguration : EntityTypeConfiguration<Turma>
    {
        public TurmaConfiguration()
        {
            ToTable("Turma");

            HasKey(t => t.TurmaId);

            Property(t => t.TipoProva).HasMaxLength(50);

            HasOptional(t => t.Professor)
                .WithMany()
                .HasForeignKey(t => t.ProfessorId);
        }
    }
}