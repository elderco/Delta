using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		[Display(Name = "Domingo")]
		public bool PodeDomingo { get; set; }
		[Display(Name = "Segunda-feira")]
		public bool PodeSegunda { get; set; }
		[Display(Name = "Terça-feira")]
		public bool PodeTerca { get; set; }
		[Display(Name = "Quarta-feira")]
		public bool PodeQuarta { get; set; }
		[Display(Name = "Quinta-feira")]
		public bool PodeQuinta { get; set; }
		[Display(Name = "Sexta-feira")]
		public bool PodeSexta { get; set; }
		[Display(Name = "Sábado")]
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
