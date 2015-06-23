using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	internal class SeedDatabase : DropCreateDatabaseIfModelChanges<Context>
	{
		protected override void Seed(Context context)
		{
			base.Seed(context);
		}
	}
}
