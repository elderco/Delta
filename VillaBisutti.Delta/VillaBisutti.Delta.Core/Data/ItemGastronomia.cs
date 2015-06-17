using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemGastronomia : DataAccessBase<Model.ItemGastronomia>
	{
		public override void Update(Model.ItemGastronomia entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.ItemGastronomia entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.ItemGastronomia entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.ItemGastronomia> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
