using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Context : DbContext
	{
		public Context()
			: base("VillaBisuttiDelta")
		{ }
		public DbSet<Model.Area> Areas { get; set; }
		public DbSet<Bebida> Bebidas { get; set; }
	}
}
