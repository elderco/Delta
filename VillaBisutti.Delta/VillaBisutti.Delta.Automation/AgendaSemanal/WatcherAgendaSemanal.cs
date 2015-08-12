using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;
using System.Threading;
using VillaBisutti.Delta.Automation.Helpers;

namespace VillaBisutti.Delta.Automation.AgendaSemanal
{
	public class WatcherAgendaSemanal : Watcher
	{
		private const string EmailAgendaSemana = "EmailAgendaSemanal.txt";
        private const string CabecalhoAgendasemanal = "CabecalhoAgendaSemanal.txt";
        public override void Run(object state)
        {
            //O serviço nunca para de executar
            TimerExecution.Change(Timeout.Infinite, Timeout.Infinite);

            EmailAgendaSemanal();
            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate();
            Date = ExtensionMethods.GetDateXML();
            Time = ExtensionMethods.ReturnTimeToRun(Date);
            TimerExecution.Change(Time, Time);

        }
        
		public void EmailAgendaSemanal()
		{
			DateTime ate = DateTime.Now.AddDays(Settings.EventosProximosDias).Date;
			DateTime de = DateTime.Now.Date;
            DateTime diasAposEventoEnvioEmail = ate.AddDays(Settings.EnviarEmailAposXDiasEvento).Date;

			string message = Util.ReadFileEmail(EmailAgendaSemana);
            string mensagemInteira = Util.ReadFileEmail(CabecalhoAgendasemanal);
            string rodape = @"*PARA VISITAR A CASA QUATÁ A ENTRADA É FEITA PELA CASA DO ATOR.
Lembrando que o melhor horário para visitação é sempre uma hora antes do descrito acima, ok?
Pois neste horário ainda não temos convidados e a casa já estará montada para o início e abertura da festa!
Um super beijo!";
            StringBuilder builder = new StringBuilder();
			List<model.Evento> proximosEventos = Util.context.Evento.Include(l => l.Local).Include(d => d.Decoracao).Where(e => DbFunctions.TruncateTime(e.Data) >= de && DbFunctions.TruncateTime(e.Data) <= ate).ToList();
            List<string> enviarEmails = Util.context.Evento.Where(e => DbFunctions.TruncateTime(e.Data) > diasAposEventoEnvioEmail).Select(a => a.EmailContato).Distinct().ToList();
            var culture = new System.Globalization.CultureInfo("pt-BR");
			foreach (model.Evento proximoeEvento in proximosEventos.OrderBy(a => a.Data))
			{
                builder.AppendLine(message.Replace("{DIAEXTENSO}", culture.DateTimeFormat.GetDayName(proximoeEvento.Data.DayOfWeek).ToString().ToUpper())
                    .Replace("{DIA}", proximoeEvento.Data.ToString("dd/MM"))
                    .Replace("{LOCAL}", proximoeEvento.Local.NomeCasa)
                    .Replace("{TIPOEVENTO}", proximoeEvento.TipoEvento.ToString())
                    .Replace("{COR}", proximoeEvento.Decoracao.CoresCerimonia.ToString())
                    .Replace("{HORA}", proximoeEvento.HorarioInicio.ToString()));  
            }
            
            message = builder.ToString();
            mensagemInteira = mensagemInteira + message + rodape;
            Core.Email mail = new Core.Email()
            {
                CCO = enviarEmails,
                Assunto = "F0DA-SE TO MANDANDO UM MONTE DE EMAIL MESMO",
                CorpoEmail = mensagemInteira,
                NomedoRemetente = "Villa Biscate"
            };
            mail.SendMail();
		}
        
        
	}
}
	