using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMFactory.Orchestration.LaunchConditions
{
    public interface IConfigurationStore
    {
        int NumberOfVMsAllowed { get; }

        string ServerName { get; }

        string Password { get;  }

        string UserName { get;  }
    }
}
