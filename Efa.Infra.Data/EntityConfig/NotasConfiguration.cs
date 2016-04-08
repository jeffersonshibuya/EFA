using System.Data.Entity.ModelConfiguration;
using Efa.Domain.Entities;

namespace Efa.Infra.Data.EntityConfig
{
    public class NotasConfiguration : EntityTypeConfiguration<Notas>
    {
        public NotasConfiguration()
        {
            ToTable("Notas");

            HasKey(n => n.NotasId);

            Property(n => n.MediaWrittenTest).IsOptional();
            Property(n => n.MediaOralTest).IsOptional();
            //Property(n => n.MediaQuiz).HasPrecision(4, 1).IsOptional();
            Property(n => n.MediaQuiz).IsOptional();
            Property(n => n.MediaWrittenTest).IsOptional();
            Property(n => n.MediaGeral).IsOptional();

            Property(n => n.Quiz1).IsOptional();
            Property(n => n.Quiz2).IsOptional();
            Property(n => n.Quiz3).IsOptional();
            Property(n => n.Quiz4).IsOptional();
            Property(n => n.Quiz5).IsOptional();
            Property(n => n.Quiz6).IsOptional();
            Property(n => n.Quiz7).IsOptional();
            Property(n => n.Quiz8).IsOptional();

            Property(n => n.WrittenTest1).IsOptional();
            Property(n => n.WrittenTest2).IsOptional();
            Property(n => n.WrittenTest3).IsOptional();
            Property(n => n.WrittenTest4).IsOptional();

            Property(n => n.OralTest1).IsOptional();
            Property(n => n.OralTest2).IsOptional();
        }
    }
}