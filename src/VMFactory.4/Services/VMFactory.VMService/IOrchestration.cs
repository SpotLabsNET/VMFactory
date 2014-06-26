using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace VMFactory.VMService
{
    [ServiceContract]
    public interface IOrchestration
    {
        [OperationContract]
        StartVmResponse StartVm(StartVmRequest request);

        [OperationContract]
        ShutdownVMResponse ShutdownVM(ShutdownVMRequest request);

        [OperationContract]
        PackVMResponse PackVM(PackVMRequest request);
    }

    #region StartVM

    [DataContract]
    public class StartVmRequest
    {
        private string _virtualMachineId;

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

        private string _userId;

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
    public class StartVmResponse
    {
        private string _virtualMachineId;

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

        private string _userId;

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

        private bool _hasErrors = true;

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

        private List<String> _errors = new List<String>();

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

        private List<String> _warnings = new List<String>();

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

        private bool _hasWarnings = true;

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
    }

    #endregion StartVM

    #region ShutdownVM

    [DataContract]
    public class ShutdownVMRequest
    {
        private string _virtualMachineId;

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

        private string _userId;

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
    public class ShutdownVMResponse
    {
        private string _virtualMachineId;

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

        private string _userId;

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

        private bool _hasErrors = true;

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

        private List<String> _errors = new List<String>();

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

        private List<String> _warnings = new List<String>();

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

        private bool _hasWarnings = true;

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
    }

    #endregion ShutdownVM

    #region PackVM

    [DataContract]
    public class PackVMRequest
    {
        private string _virtualMachineId;

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

        private string _userId;

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

        private string _tempFolderPath;

        /// <summary>
        /// Gets or sets the temp folder path.
        /// </summary>
        /// <value>
        /// The temp folder path.
        /// </value>
        [DataMember]
        public string TempFolderPath
        {
            get { return TempFolderPath; }
            set { TempFolderPath = value; }
        }

        private string _destinationFolderPath;

        [DataMember]
        public string DestinationFolderPath
        {
            get { return _destinationFolderPath; }
            set { _destinationFolderPath = value; }
        }
    }

    [DataContract]
    public class PackVMResponse
    {
        private string _virtualMachineId;

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

        private string _userId;

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

        private bool _hasErrors = true;

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

        private List<String> _errors = new List<String>();

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

        private List<String> _warnings = new List<String>();

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

        private bool _hasWarnings = true;

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

        private List<String> _packedFilesPhysicalPathsList = new List<string>();

        /// <summary>
        /// Gets or sets the packed files physical paths list.
        /// </summary>
        /// <value>
        /// The packed files physical paths list.
        /// </value>
        [DataMember]
        public List<String> PackedFilesPhysicalPathsList
        {
            get { return _packedFilesPhysicalPathsList; }
            set { _packedFilesPhysicalPathsList = value; }
        }

        private List<String> _packedFilesUrlsList = new List<string>();

        /// <summary>
        /// Gets or sets the packed files urls list.
        /// </summary>
        /// <value>
        /// The packed files urls list.
        /// </value>
        [DataMember]
        public List<String> PackedFilesUrlsList
        {
            get { return _packedFilesUrlsList; }
            set { _packedFilesUrlsList = value; }
        }

        private int _numberOfPackedFiles;

        /// <summary>
        /// Gets or sets the number of packed files.
        /// </summary>
        /// <value>
        /// The number of packed files.
        /// </value>
        [DataMember]
        public int NumberOfPackedFiles
        {
            get { return _numberOfPackedFiles; }
            set { _numberOfPackedFiles = value; }
        }
    }

    #endregion PackVM
}