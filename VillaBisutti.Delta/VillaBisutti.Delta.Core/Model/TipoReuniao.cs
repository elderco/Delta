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
		[Display(Name = "Tipo de reunião"), Required]
		public string Nome { get; set; }
		[Display(Name = "Dias Restantes até o Evento"), Range(0, 365)]
		public int DiasAntesEvento { get; set; }
		[Display(Name = "Reuniões simultâneas / tipo"), Range(0, 161)]
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
		[Display(Name = "Àrea participante")]
		public TipoAcesso AreaEnvolvida { get; set; }
		[Display(Name = "Reuniões simultâneas / área"), Range(0, 161)]
		public int MaximoAreaEnvolvida { get; set; }
		[Display(Name = "Duração")]
		public int HorarioDuracao { get; set; }
		public Horario Duracao
		{
			get
			{
				return Horario.Parse(HorarioDuracao);
			}
			set
			{
				HorarioDuracao = value.ToInt();
			}
		}
		[Display(Name = "Disponibilidade (das)")]
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

		[Display(Name = "Disponibilidade (às)")]
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
		[Display(Name = "Reunioes")]
		public List<Reuniao> Reunioes { get; set; }
	}
}
