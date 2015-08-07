using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Automation
{
	public static class Program
	{
		public static void IniciarBoasVindas()
		{
			VillaBisutti.Delta.Automation.BoasVindas.WatcherBoasVindas boasVindas = new BoasVindas.WatcherBoasVindas();
			boasVindas.EmailBoasVindas();
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
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
