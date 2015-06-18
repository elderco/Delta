using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemOutrosItemItemDiverso : DataAccessBase<Model.ItemOutrosItens>
	{
		public override void Update(Model.ItemOutrosItens entity)
		{
			Model.ItemOutrosItens original = context.ItemOutrosItens.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemOutrosItens entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemOutrosItens entity)
		{
			context.ItemOutrosItens.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemOutrosItens> GetCollection()
		{
			return context.ItemOutrosItens.ToList();
		}
	}
}

