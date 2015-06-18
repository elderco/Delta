using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemBoloDoceBemCasado : DataAccessBase<Model.ItemBoloDoceBemCasado>
	{
		public override void Update(Model.ItemBoloDoceBemCasado entity)
		{
			Model.ItemBoloDoceBemCasado original = context.ItemBoloDoceBemCasado.FirstOrDefault(b => b.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override DbEntityEntry GetCurrent(Model.ItemBoloDoceBemCasado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemBoloDoceBemCasado entity)
		{
			context.ItemBoloDoceBemCasado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemBoloDoceBemCasado> GetCollection()
		{
			return context.ItemBoloDoceBemCasado.ToList();
		}
	}
}
