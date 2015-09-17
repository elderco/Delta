using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Business
{
	public static class BoasVindas
	{
		private const String EmailBoasVindasFileName = "EmailBoasVindas.txt";
		public static void EnviaEmailBoasVindas()
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
				email.Destinatario = new List<string> { "talesdealmeida@gmail.com" };
				email.NomedoRemetente = "Ravena";
				email.SendMail();
				evento.EmailBoasVindasEnviado = true;
				Util.context.Entry(eventoAntigo).OriginalValues.SetValues(evento);
			}
			Util.context.SaveChanges();
			Util.ResetContext();
		}
	}
}
