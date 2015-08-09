using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.Automation.AgendaSemanal
{
	public class WatcherAgendaSemanal
	{
		private const string EmailAgendaSemana = "EmailAgendaSemanal";
		public void EmailAgendaSemanal()
		{
			//toda semana, num dia X, tem que mandar um email para os eventos dos tipos A,B,C... contendo os eventos dos tipos A, B, C... que vão ocorrer no fim de semana.
			//esse email manda o evento, que horas abre a casa, que tipo de evento é e quais são as cores usadas na decoração
			//esse email manda o evento = casa

			DateTime ate = DateTime.Now.AddDays(Settings.EventosProximosDias).Date;
			DateTime de = DateTime.Now.Date;
			string message = Util.ReadFileEmail(EmailAgendaSemana);
			List<model.Evento> proximosEventos = Util.context.Evento.Where(e => DbFunctions.TruncateTime(e.Data) >= de && DbFunctions.TruncateTime(e.Data) <= ate).ToList();
			List<model.Evento> enviarEmails = Util.context.Evento.Where(e => DbFunctions.TruncateTime(e.Data) > ate.AddDays(Settings.EnviarEmailAposXDiasEvento).Date).ToList();

			foreach (model.Evento proximoeEvento in proximosEventos)
			{ } 
		}
	}
}
	