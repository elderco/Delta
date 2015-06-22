using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class CronogramaCerimonialPadrao : DataAccessBase<Model.CronogramaCerimonialPadrao>
	{
		public override void Update(Model.CronogramaCerimonialPadrao entity)
		{
			Model.CronogramaCerimonialPadrao original = context.CronogramaCerimonialPadrao.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.CronogramaCerimonialPadrao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.CronogramaCerimonialPadrao entity)
		{
			context.CronogramaCerimonialPadrao.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.CronogramaCerimonialPadrao> GetCollection()
		{
			return context.CronogramaCerimonialPadrao.ToList();
		}
	}
}
