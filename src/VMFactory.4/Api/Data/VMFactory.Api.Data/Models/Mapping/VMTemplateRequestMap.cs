using System.Data.Entity.ModelConfiguration;

namespace VMFactory.Api.Data.Models.Mapping
{
    public class VMTemplateRequestMap : EntityTypeConfiguration<VMTemplateRequest>
    {
        public VMTemplateRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserEmailAddress)
                .HasMaxLength(200);

            this.Property(t => t.UserName)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("VMTemplateRequest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserEmailAddress).HasColumnName("UserEmailAddress");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.RequestDetail).HasColumnName("RequestDetail");
        }
    }
}
