using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationsService.Host
{
    class Program
    {
        public static void Main()
        {
            if (!IsProcessEvaluatedInAdminMode())
            {
                Console.WriteLine("Run program as Administrator.");
                Console.ReadKey();
                return;
            }

            ServiceHost processesServiceHost = null;
            try
            {
                //Base Address for ProcessesService
                Uri httpBaseAddress = new Uri("http://localhost:61000/ProcessesService");

                //Instantiate ServiceHost
                using (processesServiceHost = new ServiceHost(typeof(ProcessesService), httpBaseAddress))
                {
                    //Add Endpoint to Host
                    processesServiceHost.AddServiceEndpoint(typeof(IProcessesService), new BasicHttpBinding(), httpBaseAddress);

                    var behaviourAttribute = processesServiceHost.Description.Behaviors.FirstOrDefault(b => b is ServiceBehaviorAttribute) as ServiceBehaviorAttribute;
                    if (behaviourAttribute != null)
                    {
                        behaviourAttribute.IncludeExceptionDetailInFaults = true;
                    }

                    //Open
                    processesServiceHost.Open();
                    Console.WriteLine("Service is live now at: {0}", httpBaseAddress);

                    Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("I'm alive");
                        }
                    });

                    Console.ReadKey();
                }

            }
            catch (Exception ex)
            {
                processesServiceHost = null;
                Console.WriteLine("There is an issue with ProcessesService: " + ex.Message);
                Console.ReadKey();
            }
        }

        private static bool IsProcessEvaluatedInAdminMode()
        {
            bool isElevated = false;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return isElevated;
        }
    }
}
