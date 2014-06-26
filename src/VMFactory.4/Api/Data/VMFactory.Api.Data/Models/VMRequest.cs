using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VMFactory.Api.Core.Configuration;

namespace VMFactory.Api.Data.Models
{
    public partial class VMRequest
    {
        public VMRequest()
        {
            this.Id = long.MinValue;
            this.VMOutputs = new List<VMOutput>();
        }

        [DisplayName("Request id")]
        public long Id { get; set; }

        private string displayName = null;

        [DisplayName("Display name")]
        public string DisplayName
        {
            get
            {
                /// This is validation is necessary when the entity 
                /// is created in the Presentation Layer
                if (string.IsNullOrEmpty(displayName))
                    if (this.Id != long.MinValue)
                        return string.Format("{0}", Id);

                return displayName;
            }
            set
            {
                displayName = value;
            }
        }

        private string machineName = null;

        [DisplayName("Machine name")]
        public string MachineName 
        {
            get
            {
                /// This is validation is necessary when the entity 
                /// is created in the Presentation Layer
                if (string.IsNullOrEmpty(machineName))
                    if (this.Id != long.MinValue)
                        return string.Format("{0}", Id);

                return machineName;
            }
            set
            {
                machineName = value;
            }
        }

        [DisplayName("MDT Configuration")]
        public string MDTConfigurationSettings { get; set; }

        [DisplayName("Target VM configuration")]
        public string TargetConfiguration { get; set; }

        private Nullable<int> requestStatus;

        [DisplayName("request current status")]
        public Nullable<int> RequestStatus {
            get
            {
                return requestStatus;
            }
            set
            {
                requestStatus = value;
                LastUpdated = DateTime.UtcNow;
            }
        }

        private Nullable<System.DateTime> _LastUpdated;
        [DisplayName("Last modified")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> LastUpdated
        {
            get 
            {
                return _LastUpdated; 
            }

            set
            {
                _LastUpdated = value;
            }
        }

        private string processLog;

        [DisplayName("Output log")]
        public string ProcessLog 
        {
            get
            {
                return processLog;
            }
            set
            {
                processLog = null;
                if (!string.IsNullOrEmpty(value))
                    processLog = value;
                LastUpdated = DateTime.UtcNow;
            }
        }

        private Nullable<System.DateTime> _CreatedOn;
        [DisplayName("Created on")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> CreatedOn
        {
            get 
            { 
                return _CreatedOn; 
            }

            set
            {
                // default it
                if (value == null)
                {
                    _CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    _CreatedOn = value;
                }
                LastUpdated = value;
            }
        }


        private string createdBy;

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string CreatedBy 
        {
            get { return createdBy; }
            set { createdBy = value.Trim(); }
        }

        [DisplayName("Template")]
        [Required]
        public int TemplateId { get; set; }
        
        public virtual RequestStatu RequestStatu { get; set; }
        public virtual ICollection<VMOutput> VMOutputs { get; set; }
        public virtual VMTemplate VMTemplate { get; set; }

        public virtual List<RequestStatusLog> RequestStatusLogs { get; set; }

        public string DestinationFolder
        {
            get
            {
                return String.Format(
                    DefaultConfigurationStore.Current.NewVmDestinationPathTemplate,
                    this.DisplayName);
            }
        }

    }

}
