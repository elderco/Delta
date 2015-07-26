using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoPratoPadrao : IEntityBase
	{
		public int Id { get; set; }
		public int TipoPratoId { get; set; }
		public TipoPrato TipoPrato { get; set; }

		public int? CardapioId { get; set; }
		public Cardapio Cardapio { get; set; }
		public int? TipoServicoId { get; set; }
		public TipoServico TipoServico { get; set; }

		public int? EventoId { get; set; }
		public Gastronomia Gastronomia { get; set; }
		
		public int QuantidadePratos { get; set; }
	}
}
