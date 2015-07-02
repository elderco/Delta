using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class PratoSelecionado : IEntityBase
	{
		public int Id { get; set; }
		public int PratoId { get; set; }
		[Display(Name = "Prato"), Required]
		public Prato Prato { get; set; }
		public int EventoId { get; set; }
		[Display(Name = "Evento")]
		public Evento Evento { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
	}
}
