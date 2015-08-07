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

namespace VillaBisutti.Delta.Automation.BoasVindas
{
	public class WatcherBoasVindas
	{
		private Timer timerExecution { get; set; }
        private DateTime date { get; set; }
        private long time { get; set; }
		private const String EmailBoasVindasFileName = "EmailBoasVindas.txt";

		public WatcherBoasVindas()
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

			EmailBoasVindas();

            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate();
            date = ExtensionMethods.GetDateXML();
            time = ExtensionMethods.ReturnTimeToRun(date);
            timerExecution.Change(time, time);

        }

		public void EmailBoasVindas()
		{
			List<model.Evento> eventos = Util.context.Evento
				.Where(x => !String.IsNullOrEmpty(x.EmailContato) && x.EmailBoasVindasEnviado == false)
				.ToList();
			string file = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)) + "\\Padrao Emails\\" + EmailBoasVindasFileName;
			foreach (model.Evento evento in eventos)
			{
				if (File.Exists(file))
				{
					string message = ReadFile(file, evento);
					Email email = new Email();
					email.Assunto = "Oi";
					email.CorpoEmail = message;
					email.Destinatario = new List<string>() { "talesdealmeida@gmail.com", "rafael.ravena@gmail.com", "paulo.frizzo01@gmail.com" };
					email.NomedoRemetente = "Seu macho";
					email.SendMail();
				}
			}
		}

		private static string ReadFile(string file, model.Evento evento)
		{
			string message = string.Empty;
			using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				using (StreamReader reader = new StreamReader(fileStream))
				{
					return message = reader.ReadToEnd().Replace("{NOME}", evento.NomeResponsavel).Replace("{DATA}", evento.Data.ToString("dd/MM/yyyy"));
				}
			}
		}
	}
}
