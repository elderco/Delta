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
		public int? EventoId { get; set; }
		[Display(Name = "Evento")]
		public Evento Evento { get; set; }
		public int? CardapioId { get; set; }
		public Cardapio Cardapio { get; set; }
		public int? TipoServicoId { get; set; }
		public TipoServico TipoServico { get; set; }
		public bool Escolhido { get; set; }
		public bool Degustar { get; set; }
		[Display(Name = "Observações")]
		public string Observacoes { get; set; }
	}
}
