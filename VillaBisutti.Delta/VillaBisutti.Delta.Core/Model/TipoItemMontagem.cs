using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoItemMontagem : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<ItemMontagem> Itens { get; set; }
		public bool PadraoAniversario { get; set; }
		public bool PadraoBarmitzva { get; set; }
		public bool PadraoBatmitzva { get; set; }
		public bool PadraoCasamento { get; set; }
		public bool PadraoCorporativo { get; set; }
		public bool PadraoDebutante { get; set; }
		public bool PadraoOutro { get; set; }

	}
}
