using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Cardapio : IEntityBase
	{
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; }
		public List<Prato> Pratos { get; set; }
	}
}
