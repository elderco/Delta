using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemOutrosItemItemDiverso : DataAccessBase<Model.ItemOutrosItemItemDiverso>
	{
		public override void Update(Model.ItemOutrosItemItemDiverso entity)
		{
			Model.ItemOutrosItemItemDiverso original = context.IntensOutrosItensItensDiversos.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemOutrosItemItemDiverso entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemOutrosItemItemDiverso entity)
		{
			context.IntensOutrosItensItensDiversos.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemOutrosItemItemDiverso> GetCollection()
		{
			return context.IntensOutrosItensItensDiversos.ToList();
		}
	}
}

