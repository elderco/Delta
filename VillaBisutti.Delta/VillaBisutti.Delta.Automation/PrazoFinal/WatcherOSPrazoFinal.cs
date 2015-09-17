using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using VillaBisutti.Delta.Core;
using System.Threading;
using VillaBisutti.Delta.Automation.Helpers;
using bus = VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.Automation.PrazoFinal
{
	public class WatcherOSPrazoFinal : Watcher
	{
        public override void Run(object state)
        {
            TimerExecution.Change(Timeout.Infinite, Timeout.Infinite);
            bus.OSPrazoFinal.EnviaOSPrazoFinal();

            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate("DataEmailPrazoFinalOS","FrequenciaPrazoFinalOS");
            Date = ExtensionMethods.GetDateXML("DataEmailPrazoFinalOS");
            Time = ExtensionMethods.ReturnTimeToRun(Date);
            TimerExecution.Change(Time, Time);
        }
	}
}
