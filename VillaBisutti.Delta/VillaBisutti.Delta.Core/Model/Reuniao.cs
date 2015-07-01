using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class Reuniao : IEntityBase
	{
		public int Id { get; set; }
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public int TipoReuniaoId { get; set; }
		public TipoReuniao TipoReuniao { get; set; }
		public List<Usuario> Envolvidos { get; set; }
		public DateTime Data { get; set; }
		public int HorarioReuniao { get; set; }
		public Horario Horario
		{
			get
			{
				return Horario.Parse(HorarioReuniao);
			}
			set
			{
				HorarioReuniao = value.ToInt();
			}
		}
		public string Observacoes { get; set; }
		public bool Definida { get; set; }
		public bool Executada { get; set; }
	}
}
