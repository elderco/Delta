using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class Montagem
	{
		[Key, ForeignKey("Evento")]
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public string Observacoes { get; set; }
		public List<ItemMontagemSelecionado> Itens { get; set; }
	}
}
