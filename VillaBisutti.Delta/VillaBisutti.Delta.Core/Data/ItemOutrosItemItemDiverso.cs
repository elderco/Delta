using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemOutrosItemItemDiverso : DataAccessBase<Model.ItemOutroItem>
	{
		public override void Update(Model.ItemOutroItem entity)
		{
			Model.ItemOutroItem original = context.ItemOutroItem.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemOutroItem entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemOutroItem entity)
		{
			context.ItemOutroItem.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemOutroItem> GetCollection()
		{
			return context.ItemOutroItem.ToList();
		}
	}
}

