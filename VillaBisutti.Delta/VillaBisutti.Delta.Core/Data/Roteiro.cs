using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Roteiro : DataAccessBase<Model.Roteiro>
	{
		public override void Update(Model.Roteiro entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.Roteiro entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.Roteiro entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.Roteiro> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
