using System;
using VillaBisutti.Delta.Automation.Helpers;
using System.Threading;
using System.Data.Entity; 
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using VillaBisutti.Delta.Core;
using bus = VillaBisutti.Delta.Core.Business;


namespace VillaBisutti.Delta.Automation.BoasVindas
{
	public class WatcherBoasVindas : Watcher
	{
        /// <summary>
        /// Começa a execução do Robô
        /// </summary>
        /// <param name="state"></param>
        public override void Run(object state)
        {
            //O serviço nunca para de executar
            TimerExecution.Change(Timeout.Infinite, Timeout.Infinite);
			bus.BoasVindas.EnviaEmailBoasVindas();
            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate("DataEmailBoasVindas", "FrequenciaBoasVindas");
            Date = ExtensionMethods.GetDateXML("DataEmailBoasVindas");
            Time = ExtensionMethods.ReturnTimeToRun(Date);
            TimerExecution.Change(Time, Time);
        }
	}
}
