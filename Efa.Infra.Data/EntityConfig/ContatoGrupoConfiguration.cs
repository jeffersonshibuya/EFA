using System.Data.Entity.ModelConfiguration;
using Efa.Domain.Entities;

namespace Efa.Infra.Data.EntityConfig
{
    public class ContatoGrupoConfiguration : EntityTypeConfiguration<ContatoGrupo>
    {
        public ContatoGrupoConfiguration()
        {
            ToTable("Contato_Grupo");

            HasKey(c => c.ContatoGrupoId);

            Property(c => c.Nome).IsRequired();
        }
    }
}