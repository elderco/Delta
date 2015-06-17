using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemBebida : DataAccessBase<Model.ItemBebida>
	{
		public override void Update(Model.ItemBebida entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.ItemBebida entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.ItemBebida entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.ItemBebida> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
