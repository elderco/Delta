using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Prato : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		public int TipoPratoId { get; set; }
		[Display(Name = "Tipo de Prato")]
		public TipoPrato TipoPrato { get; set; }
		[Display(Name = "Cardapios")]
		public List<Cardapio> Cardapios { get; set; }
	}
}
