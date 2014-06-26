
namespace VMFactory.Api.Data.Models
{
    public partial class tblVMTemplate
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public byte[] CreatedOn { get; set; }
        public string TemplateConfig { get; set; }
    }
}
