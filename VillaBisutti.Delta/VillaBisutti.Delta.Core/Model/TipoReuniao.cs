using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		[Display(Name = "Dias antes do evento que esta reunião deve ocorrer"), Range(0, 9E6)]
		public int DiasAntesEvento { get; set; }
		[Display(Name = "Pode occorrer Domingo")] public bool PodeDomingo { get; set; }
		[Display(Name = "Pode occorrer Segunda-feira")] public bool PodeSegunda { get; set; }
		[Display(Name = "Pode occorrer Terça-feira")] public bool PodeTerca { get; set; }
		[Display(Name = "Pode occorrer Quarta-feira")] public bool PodeQuarta { get; set; }
		[Display(Name = "Pode occorrer Quinta-feira")] public bool PodeQuinta { get; set; }
		[Display(Name = "Pode occorrer Sexta-feira")] public bool PodeSexta { get; set; }
		[Display(Name = "Pode occorrer Sábado")] public bool PodeSabado { get; set; }
		[Display(Name = "Duração")]
		public int HorarioDuracao { get; set; }
		[NotMapped]
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
	}
}
