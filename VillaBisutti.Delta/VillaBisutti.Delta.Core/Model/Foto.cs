using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Foto : IEntityBase
	{
		public int Id { get; set; }
		public string URL { get; set; }
		public string Legenda { get; set; }
	}
}
