using System.Data.Entity;
using VMFactory.Api.Data.Models.Mapping;

namespace VMFactory.Api.Data.Models
{
    public partial class VMFSupportContext : DbContext
    {
        static VMFSupportContext()
        {
            Database.SetInitializer<VMFSupportContext>(null);
        }

        public VMFSupportContext()
            : base("Name=VMFSupportContext")
        {
        }

        public DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<RequestStatu> RequestStatus { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<VMOutput> VMOutputs { get; set; }
        public DbSet<VMRequest> VMRequests { get; set; }
        public DbSet<VMTemplate> VMTemplates { get; set; }
        public DbSet<VMTemplateRequest> VMTemplateRequests { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<RequestStatusLog> RequestStatusLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new C__RefactorLogMap());
            modelBuilder.Configurations.Add(new RequestStatuMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new VMOutputMap());
            modelBuilder.Configurations.Add(new VMRequestMap());
            modelBuilder.Configurations.Add(new VMTemplateMap());
            modelBuilder.Configurations.Add(new VMTemplateRequestMap());
            modelBuilder.Configurations.Add(new webpages_MembershipMap());
            modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
        }
    }
}
