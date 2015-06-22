using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemFotoVideo : DataAccessBase<Model.ItemFotoVideo>
	{
		public override void Update(Model.ItemFotoVideo entity)
		{
			Model.ItemFotoVideo original = context.ItemFotoVideo.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemFotoVideo entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemFotoVideo entity)
		{
			context.ItemFotoVideo.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemFotoVideo> GetCollection()
		{
			return context.ItemFotoVideo.ToList();
		}
	}
}
