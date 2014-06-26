using System;

namespace VMFactory.Engine
{
    static class Program
    {


        // this is a base construction app as it is easier to develop and debug 
        // should evolve to a service 
        static void Main(string[] args)
        {
            #region welcome info
            Console.WriteLine("");
            #endregion


            // Load configuration


            // should evolve to concurrent processing: parallel extensions 
            // single threading so far until stable point is reached
            BaseProcess.Current.Execute();

        }



        static void LoadConfiguration()
        { 
        
        
        
        }


        static void Help()
        {
            Console.WriteLine("No specifil help available.");
        
        }

    }
}
