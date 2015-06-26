using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoReuniao : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int DiasAntesEvento { get; set; }
		public int MaximoEventosEnvolvidos { get; set; }
		public bool PodeDomingo { get; set; }
		public bool PodeSegunda { get; set; }
		public bool PodeTerca { get; set; }
		public bool PodeQuarta { get; set; }
		public bool PodeQuinta { get; set; }
		public bool PodeSexta { get; set; }
		public bool PodeSabado { get; set; }
		public TipoAcesso AreaEnvolvida { get; set; }
		public int MaximoAreaEnvolvida { get; set; }
		public int Duracao { get; set; }
		public int HorarioDisponibilidadeInicio { get; set; }
		public Horario DisponibilidadeInicio
		{
			get
			{
				return Horario.Parse(HorarioDisponibilidadeInicio);
			}
			set
			{
				HorarioDisponibilidadeInicio = value.ToInt();
			}
		}

		public int HorarioDisponibilidadeTermino { get; set; }
		public Horario DisponibilidadeTermino
		{
			get
			{
				return Horario.Parse(HorarioDisponibilidadeTermino);
			}
			set
			{
				HorarioDisponibilidadeTermino = value.ToInt();
			}
		}
		public List<Reuniao> Reunioes { get; set; }
	}
}
