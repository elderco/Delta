﻿using System;
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
            List<model.Evento> eventos = new data.Evento().GetCollection(0)
                .Where(x => !String.IsNullOrEmpty(x.EmailContato) && x.EmailBoasVindasEnviado == false)
                .ToList();
            
            foreach (model.Evento evento in eventos)
            {
                string message = ReadFile(evento);
                Email email = new Email();
                email.Assunto = "Oi";
                email.CorpoEmail = message;
                email.Destinatario = new List<string>() { "talesdealmeida@gmail.com" };
                email.NomedoRemetente = "Seu macho";
                if (email.SendMail() == true)
                {
                    evento.EmailBoasVindasEnviado = true;
                    new data.Evento().Update(evento);
                }
            }
		}

		private static string ReadFile(model.Evento evento)
		{
			string message = string.Empty;
            string file = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)) + "\\Padrao Emails\\" + EmailBoasVindasFileName;
            if (File.Exists(file))
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        message = reader.ReadToEnd().Replace("{NOME}", evento.NomeResponsavel).Replace("{DATA}", evento.Data.ToString("dd/MM/yyyy"));
                        reader.Close();
                        reader.Dispose();
                    }
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            return message;
		}
	}
}
