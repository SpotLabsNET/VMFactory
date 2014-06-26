using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VMFactory.Api.Data.Models
{
    public partial class VMTemplateRequest
    {
        public int Id { get; set; }

        [DisplayName("User email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string UserEmailAddress { get; set; }

        [DisplayName("User name")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Request detail")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string RequestDetail { get; set; }
    }
}
