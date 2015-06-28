using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Automation
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string [] args)
		{
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (args.Length == 0)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new Service() 
			    };

                try
                {
                    ServiceBase.Run(ServicesToRun);
                }
                catch (Exception ex)
                {

                }
            }

            else if (args[0] == "/console")
            {
                Watcher wather = new Watcher();
                Console.ReadKey();
            }
            else
                //TODO Logger
                Console.ReadKey();
         }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e != null && e.ExceptionObject != null)
            {
                //TODO: Log
                //logger.Error(e.ExceptionObject as Exception);

            }
        }
	}   
}
