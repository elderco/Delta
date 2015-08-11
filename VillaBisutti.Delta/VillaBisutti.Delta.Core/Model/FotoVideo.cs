using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class FotoVideo : IEntityBase
	{
		[NotMapped]
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
		[Display(Name = "Evento")]
		public Evento Evento { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		[Display(Name = "Itens")]
		public List<ItemFotoVideoSelecionado> Itens { get; set; }
	}
}
