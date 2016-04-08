using System.Data.Entity.ModelConfiguration;
using Efa.Domain.Entities;

namespace Efa.Infra.Data.EntityConfig
{
    public class ContatoPessoaConfiguration : EntityTypeConfiguration<ContatoPessoa>
    {
        public ContatoPessoaConfiguration()
        {
            ToTable("Contato_Pessoa");

            HasKey(c => c.ContatoPessoaId);

            HasRequired(c => c.ContatoGrupo)
                .WithMany()
                .HasForeignKey(c => c.ContatoGrupoId);
        }
    }
}