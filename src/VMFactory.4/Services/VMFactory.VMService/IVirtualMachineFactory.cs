using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VMFactory.VMService
{

    [ServiceContract]
    public interface IVirtualMachineFactory
    {

        [OperationContract]
        CreateVirtualMachineResponse RequestVirtualMachine(CreateVirtualMachineRequest request);

        [OperationContract]
        GetVirtualMachineInfoResponse GetVirtualMachineInfo(GetVirtualMachineInfoRequest request);


    }


    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CreateVirtualMachineRequest
    {
        
        string _machineName;
        /// <summary>
        /// Gets or sets the name of the machine.
        /// </summary>
        /// <value>
        /// The name of the machine.
        /// </value>
        [DataMember]
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }


        string _userId;
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        [DataMember]
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        string _userEmail;
        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        [DataMember]
        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }


        string _sequence;
        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        [DataMember]
        public string Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }


    }



    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CreateVirtualMachineResponse
    {
        bool _hasErrors = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance has errors.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }


        List<String> _errors = new List<String>();
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        [DataMember]
        public List<String> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }

        List<String> _warnings = new List<String>();
        /// <summary>
        /// Gets or sets the warnings.
        /// </summary>
        /// <value>
        /// The warnings.
        /// </value>
        [DataMember]
        public List<String> Warnings
        {
            get { return _warnings; }
            set { _warnings = value; }
        }


        bool _hasWarnings = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance has warnings.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has warnings; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool HasWarnings
        {
            get { return _hasWarnings; }
            set { _hasWarnings = value; }
        }

        bool _success = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CreateVirtualMachineResponse" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        string _machineName;
        /// <summary>
        /// Gets or sets the name of the machine.
        /// </summary>
        /// <value>
        /// The name of the machine.
        /// </value>
        [DataMember]
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        string _userId;
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        [DataMember]
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        string _userEmail;
        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        [DataMember]
        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

    }



    [DataContract]
    public class ProductSerial
    {

        string _productId;
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>
        /// The product id.
        /// </value>
        [DataMember]
        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }


        string _serial;
        /// <summary>
        /// Gets or sets the serial.
        /// </summary>
        /// <value>
        /// The serial.
        /// </value>
        [DataMember]
        public string Serial
        {
            get { return _serial; }
            set { _serial = value; }
        }

    }



    [DataContract]
    public class GetVirtualMachineInfoRequest
    {

        string _virtualMachineId;
        /// <summary>
        /// Gets or sets the virtual machine id.
        /// </summary>
        /// <value>
        /// The virtual machine id.
        /// </value>
        [DataMember]
        public string VirtualMachineId
        {
            get { return _virtualMachineId; }
            set { _virtualMachineId = value; }
        }


        string _userId;
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        [DataMember]
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

    }



    [DataContract]
    public class GetVirtualMachineInfoResponse
    {

        string _virtualMachineId;
        /// <summary>
        /// Gets or sets the virtual machine id.
        /// </summary>
        /// <value>
        /// The virtual machine id.
        /// </value>
        [DataMember]
        public string VirtualMachineId
        {
            get { return _virtualMachineId; }
            set { _virtualMachineId = value; }
        }


        string _serial;
        /// <summary>
        /// Gets or sets the serial.
        /// </summary>
        /// <value>
        /// The serial.
        /// </value>
        [DataMember]
        public string Serial
        {
            get { return _serial; }
            set { _serial = value; }
        }


        bool _hasErrors = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance has errors.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }


        List<String> _errors = new List<String>();
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        [DataMember]
        public List<String> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }

        List<String> _warnings = new List<String>();
        /// <summary>
        /// Gets or sets the warnings.
        /// </summary>
        /// <value>
        /// The warnings.
        /// </value>
        [DataMember]
        public List<String> Warnings
        {
            get { return _warnings; }
            set { _warnings = value; }
        }


        bool _hasWarnings = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance has warnings.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has warnings; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool HasWarnings
        {
            get { return _hasWarnings; }
            set { _hasWarnings = value; }
        }


        string _virtualMachineDropLocation;
        /// <summary>
        /// Gets or sets the virtual machine drop location.
        /// </summary>
        /// <value>
        /// The virtual machine drop location.
        /// </value>
        [DataMember]
        public string VirtualMachineDropLocation
        {
            get { return _virtualMachineDropLocation; }
            set { _virtualMachineDropLocation = value; }
        }


        DateTime _startDateTime;
        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        /// <value>
        /// The start date time.
        /// </value>
        [DataMember]
        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }


        DateTime _endDateTime;
        /// <summary>
        /// Gets or sets the end date time.
        /// </summary>
        /// <value>
        /// The end date time.
        /// </value>
        [DataMember]
        public DateTime EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }


        TimeSpan _executionTimeSpan;
        /// <summary>
        /// Gets or sets the execution time span.
        /// </summary>
        /// <value>
        /// The execution time span.
        /// </value>
        [DataMember]
        public TimeSpan ExecutionTimeSpan
        {
            get { return _executionTimeSpan; }
            set { _executionTimeSpan = value; }
        }


        

    }

     

}
