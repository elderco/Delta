using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Gastronomia : IEntityBase
	{
		public int Id
		{
			get
			{
				return EventoId;
			}
			set { }
		}
		[Key, ForeignKey("Evento")]
		public int EventoId { get; set; }
		public string Observacoes { get; set; }
		[Display(Name = "Evento")]
		public Evento Evento { get; set; }
		public List<PratoSelecionado> Pratos { get; set; }
		public List<TipoPratoPadrao> TiposPratos { get; set; }
	}
}
