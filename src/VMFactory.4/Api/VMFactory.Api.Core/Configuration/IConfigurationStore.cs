
namespace VMFactory.Api.Core.Configuration
{
    public interface IConfigurationStore
    {
        int NumberOfVMsAllowed { get; }

        string ServerName { get; }

        string Password { get;  }

        string UserName { get;  }

        long VhdSplitBlockSize { get; }

    }
}
