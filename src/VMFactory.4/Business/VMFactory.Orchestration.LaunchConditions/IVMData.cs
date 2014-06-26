
namespace VMFactory.Orchestration.LaunchConditions
{
    public interface IVMData
    {
        int GetNumberOfRunningVMs(string servername, string username, string password);
    }
}
