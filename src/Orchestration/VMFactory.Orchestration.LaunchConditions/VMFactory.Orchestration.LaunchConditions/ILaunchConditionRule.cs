using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMFactory.Orchestration.LaunchConditions
{
    internal interface ILaunchConditionRule
    {
        bool Check();
    }
}
