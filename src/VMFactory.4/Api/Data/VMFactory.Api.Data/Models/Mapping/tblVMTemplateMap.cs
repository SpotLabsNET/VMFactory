using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VMFactory.Api.Data.Models.Mapping
{
    public class tblVMTemplateMap : EntityTypeConfiguration<tblVMTemplate>
    {
        public tblVMTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TemplateName)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.CreatedOn)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            this.Property(t => t.TemplateConfig)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("tblVMTemplate");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TemplateName).HasColumnName("TemplateName");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.TemplateConfig).HasColumnName("TemplateConfig");
        }
    }
}
