using System.Data.Entity.ModelConfiguration;

namespace VMFactory.Api.Data.Models.Mapping
{
    public class RequestStatuMap : EntityTypeConfiguration<RequestStatu>
    {
        public RequestStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("RequestStatus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StepSequence).HasColumnName("StepSequence");
        }
    }
}
