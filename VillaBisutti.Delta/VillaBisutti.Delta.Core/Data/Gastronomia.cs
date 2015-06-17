using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Gastronomia : DataAccessBase<Model.Gastronomia>
	{
		public override void Update(Model.Gastronomia entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.Gastronomia entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.Gastronomia entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.Gastronomia> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
