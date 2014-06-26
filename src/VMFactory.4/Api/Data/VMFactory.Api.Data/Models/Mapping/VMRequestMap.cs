using System.Data.Entity.ModelConfiguration;

namespace VMFactory.Api.Data.Models.Mapping
{
    public class VMRequestMap : EntityTypeConfiguration<VMRequest>
    {
        public VMRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DisplayName)
                .HasMaxLength(128);

            this.Property(t => t.MachineName)
                .HasMaxLength(20);

            this.Property(t => t.CreatedBy)
                .IsFixedLength()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("VMRequest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
            this.Property(t => t.MachineName).HasColumnName("MachineName");
            this.Property(t => t.MDTConfigurationSettings).HasColumnName("MDTConfigurationSettings");
            this.Property(t => t.TargetConfiguration).HasColumnName("TargetConfiguration");
            this.Property(t => t.RequestStatus).HasColumnName("RequestStatus");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.ProcessLog).HasColumnName("ProcessLog");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.TemplateId).HasColumnName("TemplateId");

            // Relationships
            this.HasOptional(t => t.RequestStatu)
                .WithMany(t => t.VMRequests)
                .HasForeignKey(d => d.RequestStatus);
            this.HasRequired(t => t.VMTemplate)
                .WithMany(t => t.VMRequests)
                .HasForeignKey(d => d.TemplateId);

        }
    }
}
