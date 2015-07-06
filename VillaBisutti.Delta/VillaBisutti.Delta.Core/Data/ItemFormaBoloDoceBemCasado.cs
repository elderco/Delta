using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemFormaBoloDoceBemCasado : DataAccessBase<Model.ItemFormaBoloDoceBemCasado>
	{
		public override void Update(Model.ItemFormaBoloDoceBemCasado entity)
		{
			Model.ItemFormaBoloDoceBemCasado original = context.ItemFormaBoloDoceBemCasado.FirstOrDefault(s => s.Id == (entity.Id));
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemFormaBoloDoceBemCasado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemFormaBoloDoceBemCasado entity)
		{
			context.ItemFormaBoloDoceBemCasado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemFormaBoloDoceBemCasado> GetCollection()
		{
			return context.ItemFormaBoloDoceBemCasado.Include(ib => ib.Fornecedor).ToList();
		}
	}
}
