using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoPrato : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome")]
		public string Nome { get; set; }
		[Display(Name = "Pratos")]
		public List<Prato> Pratos { get; set; }
	}
}
