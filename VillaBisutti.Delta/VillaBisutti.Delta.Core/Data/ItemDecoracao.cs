using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemDecoracao : DataAccessBase<Model.ItemDecoracao>
	{
		public override void Update(Model.ItemDecoracao entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.ItemDecoracao entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.ItemDecoracao entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.ItemDecoracao> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
