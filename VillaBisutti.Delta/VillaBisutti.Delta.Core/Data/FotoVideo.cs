using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	class FotoVideo : DataAccessBase<Model.FotoVideo>
	{
		public override void Update(Model.FotoVideo entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.FotoVideo entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.FotoVideo entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.FotoVideo> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
