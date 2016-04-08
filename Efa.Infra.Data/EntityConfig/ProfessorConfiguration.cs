using Efa.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Efa.Infra.Data.EntityConfig
{
    public class ProfessorConfiguration : EntityTypeConfiguration<Professor>
    {
        public ProfessorConfiguration()
        {
            ToTable("Professor");

            HasKey(p => p.ProfessorId);

            Property(p => p.Nome).IsRequired();

            Property(p => p.Email).HasMaxLength(120);
            
            Property(p => p.CPF).HasMaxLength(14);

            Property(p => p.Telefone).HasMaxLength(10);

            Property(p => p.Celular).HasMaxLength(10);

            Ignore(p => p.ResultadoValidacao);


        }
    }
}
