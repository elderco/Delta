using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class Decoracao : IEntityBase
	{
		public int Id { get; set; }
		[Key, ForeignKey("Evento")]
		public int EventoId { get; set; }
		[Display(Name = "Evento"), Required]
		public Evento Evento { get; set; }
		[Display(Name = "Cores & Cerimonia")]
		public string CoresCerimonia { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
		[Display(Name = "Itens")]
		public List<ItemDecoracaoSelecionado> Itens { get; set; }
		[Display(Name = "Fotos")]
		public List<Foto> Fotos { get; set; }
	}
}
