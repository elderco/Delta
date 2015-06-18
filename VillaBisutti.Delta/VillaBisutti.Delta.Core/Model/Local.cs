using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class Local : IEntityBase
	{
		public int Id { get; set; }
		public string NomeCasa { get; set; }
		public string SiglaCasa { get; set; }
		public string EnderecoCasa { get; set; }
	}
}
