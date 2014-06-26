using System.Collections.Generic;

namespace VMFactory.Api.HyperV
{
    public static class Definitions
    {
        public static List<string> HypervCommands = new List<string>() { string.Empty, "CreateVm.ps1 ", "StartVm.ps1 ", "StopVm.ps1 ", "RemoveVm.ps1 ", "HelloWorld.ps1", "VMCopyAndImport.ps1 ", "PreLoadVHDBootData.ps1 " };
    }
}
