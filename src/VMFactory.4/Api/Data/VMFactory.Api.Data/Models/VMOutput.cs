using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VMFactory.Api.Data.Models
{
    public partial class VMOutput
    {
        public int Id { get; set; }
        public int VMTemplateId { get; set; }
        public long VMRequestId { get; set; }

        [DisplayName("File name")]
        [Required]
        public string FileName { get; set; }

        [DisplayName("Download URL")]
        [DataType(DataType.Url)]
        [Required]
        public string DownloadUrl { get; set; }

        public string Log { get; set; }

        private Nullable<System.DateTime> _CreatedOn;
        [DisplayName("Created on")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> CreatedOn 
        {
            get { return _CreatedOn; }
            
            set
            {
                // default it
                if (value == null)
                    _CreatedOn = DateTime.UtcNow;
                else
                    _CreatedOn = value;
            } 
        }


        private Nullable<System.DateTime> _LastModified;
        [DisplayName("Last modified")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> LastModified
        {
            get { return _LastModified; }

            set
            {
                // default it
                if (value == null)
                    _LastModified = DateTime.UtcNow;
            }
        }
        public virtual VMTemplate VMTemplate { get; set; }
        public virtual VMRequest VMRequest { get; set; }
    }
}
