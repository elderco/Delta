using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class RoteiroPadrao : DataAccessBase<Model.RoteiroPadrao>
	{
		public override void Update(Model.RoteiroPadrao entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.RoteiroPadrao entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.RoteiroPadrao entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.RoteiroPadrao> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
