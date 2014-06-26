using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace VMFactory.Presentation.Models
{
    public class UsersContext : DbContext { public UsersContext() : base("DefaultConnection") { }  public DbSet<UserProfile> UserProfiles { get; set; } public DbSet<InvitationCode> InvitationCodes { get; set; } }

    [Table("UserProfile")]
    public class UserProfile { [Key] [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] public int UserId { get; set; } public string UserName { get; set; } public string NameIdentifier { get; set; } public string EMail { get; set; }  }

    [Table("InvitationCodes")]
    public class InvitationCode { [Key] [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] public int Id { get; set; } public string Code { get; set; } public string UsedBy { get; set; }   } 
    public class RegisterModel { [Required] [Display(Name = "Name")] public string Name { get; set; }  [Required] [DataType(DataType.EmailAddress)] [Display(Name = "E-Mail")] public string EMail { get; set; }  [Required] [DataType(DataType.Text)] [Display(Name = "Invitation Code")] public string InvitationCode { get; set; } }
}
