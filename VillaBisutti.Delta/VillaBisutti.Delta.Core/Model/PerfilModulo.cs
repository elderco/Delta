using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class PerfilModulo : IEntityBase
	{
		public int Id { get; set; }
		public int ModuloId { get; set; }
		public Modulo Modulo { get; set; }
		public bool PodeLer { get; set; }
		public bool PodeAlterar { get; set; }
	}
}
