using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class BoloDoceBemCasado : DataAccessBase<Model.BoloDoceBemCasado>
	{
		public override void Update(Model.BoloDoceBemCasado entity)
		{
			Model.BoloDoceBemCasado original = context.BoloDoceBemCasado.FirstOrDefault(s => s.Id == (entity.Id));
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.BoloDoceBemCasado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.BoloDoceBemCasado entity)
		{
			context.BoloDoceBemCasado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.BoloDoceBemCasado> GetCollection()
		{
			return context.BoloDoceBemCasado.ToList();
		}
	}
}
