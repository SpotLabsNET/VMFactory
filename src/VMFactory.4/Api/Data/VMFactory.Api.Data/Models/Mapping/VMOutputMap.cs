using System.Data.Entity.ModelConfiguration;

namespace VMFactory.Api.Data.Models.Mapping
{
    public class VMOutputMap : EntityTypeConfiguration<VMOutput>
    {
        public VMOutputMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FileName)
                .HasMaxLength(128);

            this.Property(t => t.DownloadUrl)
                .HasMaxLength(512);

            // Table & Column Mappings
            this.ToTable("VMOutput");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VMTemplateId).HasColumnName("VMTemplateId");
            this.Property(t => t.VMRequestId).HasColumnName("VMRequestId");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.DownloadUrl).HasColumnName("DownloadUrl");
            this.Property(t => t.Log).HasColumnName("Log");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.LastModified).HasColumnName("LastModified");

            // Relationships
            this.HasRequired(t => t.VMTemplate)
                .WithMany(t => t.VMOutputs)
                .HasForeignKey(d => d.VMTemplateId);
            this.HasRequired(t => t.VMRequest)
                .WithMany(t => t.VMOutputs)
                .HasForeignKey(d => d.VMRequestId);

        }
    }
}
