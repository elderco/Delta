using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using VillaBisutti.Delta.Core.Business;
using System.Threading;
using VillaBisutti.Delta.Automation.Helpers;
using bus = VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.Automation.ContratacaoServicoTerceiro
{
    public class WacherContratacaoServicoTerceiro : Watcher
    {
        public override void Run(object state)
        {
            TimerExecution.Change(Timeout.Infinite, Timeout.Infinite);
            bus.ContratacaoServicoTerceiro.EnviaContratacaoServicoTerceiro();
            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate("DataEmailContrataServTerceiro", "FrequenciaContrataServTerceiro");
            Date = ExtensionMethods.GetDateXML("DataEmailContrataServTerceiro");
            Time = ExtensionMethods.ReturnTimeToRun(Date);
            TimerExecution.Change(Time, Time);
        }
    }
}
