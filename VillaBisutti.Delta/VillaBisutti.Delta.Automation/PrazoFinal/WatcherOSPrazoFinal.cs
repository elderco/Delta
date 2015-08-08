using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using VillaBisutti.Delta.Core;

namespace VillaBisutti.Delta.Automation.PrazoFinal
{
	public class WatcherOSPrazoFinal
	{
		private const String OSPrazoFinal = "EmailOSPrazoFinal.txt";
		private const String AcabouPrazo = "EmailAcabouPrazo.txt";
		public void EmailPrazoFinalOS()
		{
			int[] dias = Settings.QuantidadesDiasAntesEvento;
			List<model.Evento> eventos = Util.context.Evento.Where(e => e.OSFinalizada == false).ToList();
			foreach (model.Evento item in eventos)
			{
				int diasRestantes = (item.Data.Date - DateTime.Now.Date).Days;
				if (dias.Contains(diasRestantes))
				{
					string message = Util.ReadFileEmail(item, OSPrazoFinal)
					.Replace("{NOME}", item.NomeResponsavel)
					.Replace("{DIAS}", Convert.ToString(diasRestantes))
					.Replace("{LINK}", "https://www.google.com.br/search?q=como+vc+%C3%A9+burro+cara&espv=2&biw=1274&bih=538&tbm=isch&imgil=4s4W2koKPi-BMM%253A%253BGumIEHlx4ekLYM%253Bhttp%25253A%25252F%25252Fwww.sequelanet.com.br%25252F2014%25252F09%25252Fmeme-caetano-veloso-como-voce-e-burro.html&source=iu&pf=m&fir=4s4W2koKPi-BMM%253A%252CGumIEHlx4ekLYM%252C_&usg=__m9j8tnYi8cdnweCC58PDJRBjfh4%3D&ved=0CCYQyjdqFQoTCJCN85ajmMcCFQIRkAodosAKLQ&ei=VlPFVZCKB4KiwASigavoAg#imgrc=4s4W2koKPi-BMM%3A&usg=__m9j8tnYi8cdnweCC58PDJRBjfh4%3D");
					Email email = new Email();
					email.Assunto = "Oi";
					email.CorpoEmail = message;
					email.Destinatario = new List<string>() { "talesdealmeida@gmail.com", "rafael.ravena@gmail.com", "paulofrizzo01@gmail.com", "leal_554@msn.com" };
					email.NomedoRemetente = "Seu macho";
					email.SendMail();
				}
				if (Settings.AcabouPrazoEvento == diasRestantes)
				{
					string message = Util.ReadFileEmail(item, AcabouPrazo);
					Email email = new Email();
					email.Assunto = "Oi";
					email.CorpoEmail = message;
					email.Destinatario = new List<string>() { "talesdealmeida@gmail.com", "rafael.ravena@gmail.com", "paulofrizzo01@gmail.com", "leal_554@msn.com" };
					email.NomedoRemetente = "Seu macho";
					email.SendMail();
				}
			}
			
		}
	}
}
