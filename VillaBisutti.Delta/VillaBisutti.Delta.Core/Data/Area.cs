using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Area : DataAccessBase<Model.Area>
	{
		public override void Update(Model.Area entity)
		{
			Model.Area original = context.Areas.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Area entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Area entity)
		{
			context.Areas.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Area> GetCollection()
		{
			return context.Areas.ToList();
		}
	}
}
