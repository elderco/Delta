using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class RoteiroPadrao : IEntityBase
	{
		public int Id { get; set; }
		public TipoEvento TipoEvento { get; set; }
		public List<ItemRoteiro> Acontecimentos { get; set; }
	}
}
