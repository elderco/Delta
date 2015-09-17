using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VillaBisutti.Delta.Automation.BoasVindas;
using VillaBisutti.Delta.Automation.Helpers;

namespace VillaBisutti.Delta.Automation
{
    public abstract class Watcher
    {
		public Timer TimerExecution { get; set; }
		public DateTime Date { get; set; }
		public long Time { get; set; }
		public bool IsSetToRun { get; set; }
        public void Set(long time, DateTime date)
        {
            //TODO: verificar como vai ficar isso aqui já que precisa de parametro e é dinamico
            Date = ExtensionMethods.GetDateXML("");
            Time = ExtensionMethods.ReturnTimeToRun(date);
            TimerExecution = new Timer(new TimerCallback(Run), null, time, time);
        }
        public abstract void Run(object state);

		public static Watcher Factory(string qual)
		{
			return new WatcherBoasVindas();
		}
    }
}
