using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class DecoracaoCerimonial : IEntityBase
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
		[Display(Name = "Cores & Cerimonia")]
		public string CoresCerimonia { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		[Display(Name = "Itens")]
		public List<ItemDecoracaoCerimonialSelecionado> Itens { get; set; }
		[Display(Name = "Fotos")]
		public List<Foto> Fotos { get; set; }
	}
}
