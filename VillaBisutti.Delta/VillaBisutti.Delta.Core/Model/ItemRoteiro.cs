using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemRoteiro : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Título")]
		public string Titulo { get; set; }
		public int HorarioInicio { get; set; }
		[Display(Name = "Início")]
		public Horario Inicio
		{
			get
			{
				return Horario.Parse(HorarioInicio);
			}
			set
			{
				HorarioInicio = value.ToInt();
			}
		}
		public bool Importante { get; set; }
		[Display(Name = "Observação")]
		public string Observacao { get; set; }
		public int? RoteiroPadraoId { get; set; }
		public RoteiroPadrao RoteiroPadrao { get; set; }
		public int? RoteiroId { get; set; }
		public Roteiro Roteiro { get; set; }
	}
}
