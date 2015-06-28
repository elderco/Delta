    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VillaBisutti.Delta.Automation.Helpers;

namespace VillaBisutti.Delta.Automation
{
    public class Watcher
    {
        private Timer timerExecution { get; set; }
        private DateTime date { get; set; }
        private long time { get; set; }

        public Watcher()
        {
            //Define o tempo de execução cadastrado no (banco ou xml)
            date = ExtensionMethods.GetDateXML();
            time = ExtensionMethods.ReturnTimeToRun(date);
            timerExecution = new Timer(new TimerCallback(Run), null, time, time);
        }
        /// <summary>
        /// Começa a execução do Robô
        /// </summary>
        /// <param name="state"></param>
        private void Run(object state)
        {
            //O serviço nunca para de executar
            timerExecution.Change(Timeout.Infinite, Timeout.Infinite);

            //TODO: inicio da lógica da execuçao dos Robôs

            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate();
            date = ExtensionMethods.GetDateXML();
            time = ExtensionMethods.ReturnTimeToRun(date);
            timerExecution.Change(time, time);

        }
    }
}
