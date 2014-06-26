
namespace VMFactory.Api.Business.Entity
{

    /// <summary>
    /// Execution status of a request
    /// </summary>
    /// <remarks>This maps directly into the [VMFSupport].[dbo].[RequestStatus] table.</remarks>
    public enum RequestStatus : int { None = 1, Queued = 2, InProgress = 3, InstallationCompleted = 4, Packaging = 5, PackagingCompleted = 6, Deploying = 7, Deployed = 8, ReadyForPickup = 9, GarbageCollecting = 10, GarbageCollected = 11, Failed = 100 }
}
