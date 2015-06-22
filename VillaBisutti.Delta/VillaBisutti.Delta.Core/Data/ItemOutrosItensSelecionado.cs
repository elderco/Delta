using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemOutrosItensSelecionado : DataAccessBase<Model.OutroItem>
	{
		public override void Update(Model.OutroItem entity)
		{
			Model.OutroItem original = context.OutroItem.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.OutroItem entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.OutroItem entity)
		{
			context.OutroItem.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.OutroItem> GetCollection()
		{
			return context.OutroItem.ToList();
		}
	}
}
