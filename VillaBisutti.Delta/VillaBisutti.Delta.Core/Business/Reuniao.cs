using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Business
{
	public class Reuniao
	{
		public Data.Context context
		{
			get
			{
				return Util.context;
			}
		}
		public void CopiarReunioesPadrao(int eventoId)
		{
			Model.Evento evento = context.Evento.Include(e => e.Reunioes).FirstOrDefault(e => e.Id == eventoId);
			foreach (Model.TipoReuniao tipo in context.TipoReuniao.ToList())
			{
				context.Reuniao.Add(new Model.Reuniao {
					EventoId = eventoId,
					TipoReuniaoId = tipo.Id,
					Data = AchaData(tipo.DiasAntesEvento, evento.Data, tipo.PodeDomingo, tipo.PodeSegunda,
						tipo.PodeTerca,tipo.PodeQuarta,tipo.PodeQuinta,tipo.PodeSexta,tipo.PodeSabado),
					HorarioReuniao = new Model.Horario{Hora = 15}.ToInt() -  tipo.HorarioDuracao,
					Definida = false,
					Executada = false
				});
			}
			context.SaveChanges();
		}
		private DateTime AchaData(int dias, DateTime dataRef, bool Domingo, bool Segunda, bool Terca, bool Quarta, bool Quinta, bool Sexta, bool Sabado)
		{
			DateTime dia = dataRef.AddDays(-dias);
			for (int i = 0; i < 4; i++)
			{
				if (dia.AddDays(i).DayOfWeek == DayOfWeek.Sunday && Domingo)
					return dia.AddDays(i);
				if (dia.AddDays(-i).DayOfWeek == DayOfWeek.Sunday && Domingo)
					return dia.AddDays(-i);
				if (dia.AddDays(i).DayOfWeek == DayOfWeek.Monday && Segunda)
					return dia.AddDays(i);
				if (dia.AddDays(-i).DayOfWeek == DayOfWeek.Monday && Segunda)
					return dia.AddDays(-i);
				if (dia.AddDays(i).DayOfWeek == DayOfWeek.Tuesday && Terca)
					return dia.AddDays(i);
				if (dia.AddDays(-i).DayOfWeek == DayOfWeek.Tuesday && Terca)
					return dia.AddDays(-i);
				if (dia.AddDays(i).DayOfWeek == DayOfWeek.Wednesday && Quarta)
					return dia.AddDays(i);
				if (dia.AddDays(-i).DayOfWeek == DayOfWeek.Wednesday && Quarta)
					return dia.AddDays(-i);
				if (dia.AddDays(i).DayOfWeek == DayOfWeek.Thursday && Quinta)
					return dia.AddDays(i);
				if (dia.AddDays(-i).DayOfWeek == DayOfWeek.Thursday && Quinta)
					return dia.AddDays(-i);
				if (dia.AddDays(i).DayOfWeek == DayOfWeek.Friday && Sexta)
					return dia.AddDays(i);
				if (dia.AddDays(-i).DayOfWeek == DayOfWeek.Friday && Sexta)
					return dia.AddDays(-i);
				if (dia.AddDays(i).DayOfWeek == DayOfWeek.Saturday && Sabado)
					return dia.AddDays(i);
				if (dia.AddDays(-i).DayOfWeek == DayOfWeek.Saturday && Sabado)
					return dia.AddDays(-i);
			}
			return DateTime.MaxValue;
		}
	}
}
