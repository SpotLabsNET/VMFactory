using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMFactory.Api.HyperV;

namespace TestCallPSLib
{
    class Program
    {
        public static void TestHelloWorldPS()
        {




            try
            {
                Console.WriteLine("Starting");

                // instantiate a PowerShell Interfae Object
                // 
                VMFactory.Api.HyperV.PsInterface psi = new PsInterface();

                // create the list of parameters to add to the PS execution in the format NAME/VALUE pairs
                Dictionary<String, object> parameters = new Dictionary<string, object>();
                parameters.Add("paramName", "paramValue");

                // define the type of operation. This is an enumeration and can/shuld be extended as needed
                psi.Command = PsOperation.HelloWorld;

                // set the VM Name
                psi.VmName = "TestVM";

                // set the PS Command Parameters
                psi.Parameters = parameters;

                PsExecutionResult result = psi.Execute();

                // test command execution result
                if (result.Success)
                {
                    Console.WriteLine("Success!!");

                    // print the command output
                    Console.WriteLine(result.ResultMessage);
                }
                else
                {
                    Console.WriteLine(result.ResultMessage);

                    // Access the exception data
                    Console.WriteLine(result.Exception.Message);
                    Console.WriteLine(result.Exception.StackTrace);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace));
            }
            finally
            {
                Console.WriteLine("Finished. Press ENTER to exit");
                Console.ReadLine();
            }
        }


        public static void TestPreLoadVHDBootData()
        {
            try
            {
                Console.WriteLine("Starting - PreLoadVHDBootData");

                // instantiate a PowerShell Interfae Object
                // 
                VMFactory.Api.HyperV.PsInterface psi = new PsInterface();

                // create the list of parameters to add to the PS execution in the format NAME/VALUE pairs
                Dictionary<String, String> parameters = new Dictionary<string, string>();
                parameters.Add("vhdPath", "d:\\_VMs\\SP2013\\PTMoss2k13.vhd");
                parameters.Add("driveLetter", "x:");
                parameters.Add("dismPath", "C:\\Windows\\System32\\");
                parameters.Add("vmName", "MyTestVm");
                parameters.Add("vmId", "{6172815E-4839-4C80-A55E-DE4DEF52C54B}");
                parameters.Add("vmStatusSvcUrl", "http://yadayada");
                parameters.Add("cfgFileName", "VMFConfigTest.xml");

                // define the type of operation. This is an enumeration and can/shuld be extended as needed
                psi.Command = PsOperation.PreLoadVHDBootData;

                // set the VM Name
                psi.VmName = "MyTestVm";

                // set the PS Command Parameters
                //psi.Parameters = parameters;

                PsExecutionResult result = psi.Execute();

                // test command execution result
                if (result.Success)
                {
                    Console.WriteLine("Success!!");

                    // print the command output
                    Console.WriteLine(result.ResultMessage);
                }
                else
                {
                    Console.WriteLine(result.ResultMessage);

                    // Access the exception data
                    Console.WriteLine(result.Exception.Message);
                    Console.WriteLine(result.Exception.StackTrace);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace));
            }
            finally
            {
                Console.WriteLine("Finished. Press ENTER to exit");
                Console.ReadLine();
            }
        }




        public static void TestVMCopyAndImportVM()
        {
            try
            {
                Console.WriteLine("Starting - VMCopyAndImportVM");

                // instantiate a PowerShell Interfae Object
                // 
                VMFactory.Api.HyperV.PsInterface psi = new PsInterface();

                // create the list of parameters to add to the PS execution in the format NAME/VALUE pairs
                Dictionary<String, object> parameters = new Dictionary<string, object>();

                parameters.Add("Source", "D:\\_VMs\\base");
                parameters.Add("Destination", "D:\\_VMs\\NewTest\\");
                parameters.Add("VMPath", "D:\\_VMs\\base\\VMFTestBoot\\Virtual Machines\\2E4588A4-A37A-4A33-ABA7-E7A9A7C1D8F2.xml");
                parameters.Add("vmName", "MyTestVm");
                parameters.Add("VMBaseName", "BASE_VMF_VM");

                // define the type of operation. This is an enumeration and can/shuld be extended as needed
                psi.Command = PsOperation.VMCopyAndImport;

                // set the VM Name
                psi.VmName = "MyTestVm";

                // set the PS Command Parameters
                psi.Parameters = parameters;

                PsExecutionResult result = psi.Execute();

                // test command execution result
                if (result.Success)
                {
                    Console.WriteLine("Success!!");

                    // print the command output
                    Console.WriteLine(result.ResultMessage);
                }
                else
                {
                    Console.WriteLine(result.ResultMessage);

                    // Access the exception data
                    Console.WriteLine(result.Exception.Message);
                    Console.WriteLine(result.Exception.StackTrace);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace));
            }
            finally
            {
                Console.WriteLine("Finished. Press ENTER to exit");
                Console.ReadLine();
            }
        }



        public static PsExecutionResult StartVM(string vmName)
        {
            PsExecutionResult result = null;
            try
            {
                Console.WriteLine("Starting - StartVM");

                // instantiate a PowerShell Interfae Object
                // 
                VMFactory.Api.HyperV.PsInterface psi = new PsInterface();

                // create the list of parameters to add to the PS execution in the format NAME/VALUE pairs
                Dictionary<String, object> parameters = new Dictionary<string, object>();

                parameters.Add("vmName", vmName);

                // define the type of operation. This is an enumeration and can/shuld be extended as needed
                psi.Command = PsOperation.StartVm;
                
                // set the VM Name
                //psi.VmName = "MyTestVm";

                // set the PS Command Parameters
                psi.Parameters = parameters;

                result = psi.Execute();

                // test command execution result
                if (result.Success)
                {
                    Console.WriteLine("Success!!");

                    // print the command output
                    Console.WriteLine(result.ResultMessage);
                }
                else
                {
                    Console.WriteLine(result.ResultMessage);

                    // Access the exception data
                    Console.WriteLine(result.Exception.Message);
                    Console.WriteLine(result.Exception.StackTrace);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace));
            }
            finally
            {
                Console.WriteLine("Finished. Press ENTER to exit");
                Console.ReadLine();
            }
            return result;
        }





        static void Main(string[] args)
        {
            //TestHelloWorldPS();
            //TestPreLoadVHDBootData();
            //TestVMCopyAndImportVM();
            // StartVM("MyTestVm");
            PsExecutionResult result = StartVM("DevOps");

            Console.WriteLine("Result message is {0} and the result is {1}", result.ResultMessage, result.Success);
            return;
        }
    }
}
