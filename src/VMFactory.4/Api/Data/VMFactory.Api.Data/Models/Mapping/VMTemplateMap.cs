using System.Data.Entity.ModelConfiguration;

namespace VMFactory.Api.Data.Models.Mapping
{
    public class VMTemplateMap : EntityTypeConfiguration<VMTemplate>
    {
        public VMTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UniqueName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("VMTemplate");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UniqueName).HasColumnName("UniqueName");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
            this.Property(t => t.MdtBaseConfig).HasColumnName("MdtBaseConfig");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.LastModified).HasColumnName("LastModified");
        }
    }
}
