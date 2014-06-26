using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace VMFactory.Orchestration.LaunchConditions.Client
{
    class Program
    {
        static void Main(string[] args)
        {
          
            ValidateLaunch vl = new ValidateLaunch();
            bool result = vl.VerifyLaunchConditions();
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
