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
					.Include(e => e.Bebida)
					.Include(e => e.BoloDoceBemCasado)
					.Include(e => e.Cardapio)
					.Include(e => e.DecoracaoCerimonial)
					.Include(e => e.FotoVideo)
					.Include(e => e.Gastronomia)
					.Include(e => e.Local)
					.Include(e => e.Montagem)
					.Include(e => e.OutrosItens)
					.Include(e => e.PosVendedora)
					.Include(e => e.Produtora)
					.Include(e => e.SomIluminacao)
				.Where(x => !String.IsNullOrEmpty(x.EmailContato) && x.EmailBoasVindasEnviado == false).ToList();
            string message = Util.ReadFileEmail(EmailBoasVindasFileName);
            foreach (model.Evento evento in eventos)
            {
				model.Evento eventoAntigo = Util.context.Evento.Find(evento.Id);
				message.Replace("{NOME}", evento.NomeResponsavel).Replace("{DATA}", evento.Data.ToString("dd/MM/yyyy"));
                Email email = new Email();
                email.Assunto = "Oi";
                email.CorpoEmail = message;
                email.Destinatario = new List<string>() { "talesdealmeida@gmail.com" };
                email.NomedoRemetente = "Seu macho";
				email.SendMail();
				evento.EmailBoasVindasEnviado = true;
				Util.context.Entry(eventoAntigo).OriginalValues.SetValues(evento);
            }
			Util.context.SaveChanges();
			Util.ResetContext();
		}
	}
}
