using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class CronogramaCerimonial : DataAccessBase<Model.CronogramaCerimonial>
	{
		public override void Update(Model.CronogramaCerimonial entity)
		{
			Model.CronogramaCerimonial original = context.CronogramaCerimonial.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.CronogramaCerimonial entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.CronogramaCerimonial entity)
		{
			context.CronogramaCerimonial.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.CronogramaCerimonial> GetCollection()
		{
			return context.CronogramaCerimonial.ToList();
		}
	}
}
