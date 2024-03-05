using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mostidea.Domain;

namespace Mostidea.Infrastracture.Config
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<FileModel>
    {
        public void Configure(EntityTypeBuilder<FileModel> builder)
        {
            //builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
