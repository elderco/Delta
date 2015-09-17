using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using bus = VillaBisutti.Delta.Core.Business;
using System.Threading;
using VillaBisutti.Delta.Automation.Helpers;

namespace VillaBisutti.Delta.Automation.OSFinalizada
{
	public class WatcherOSFinalizada: Watcher
	{
        public override void Run(object state)
        {
            TimerExecution.Change(Timeout.Infinite, Timeout.Infinite);
            bus.OSFinalizada.EnviaOSFinalizada();
            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate("DataFinalizacaoOS","FrequenciaOSFinalizada");
            Date = ExtensionMethods.GetDateXML("DataFinalizacaoOS");
            Time = ExtensionMethods.ReturnTimeToRun(Date);
            TimerExecution.Change(Time, Time);
        }
		
	}
}
