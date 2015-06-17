using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class BoloDoceBemCasado : DataAccessBase<Model.BoloDoceBemCasado>
	{
		public override void Update(Model.BoloDoceBemCasado entity)
		{
			Model.BoloDoceBemCasado original = context.BolosDocesBemCasados.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.BoloDoceBemCasado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.BoloDoceBemCasado entity)
		{
			context.BolosDocesBemCasados.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.BoloDoceBemCasado> GetCollection()
		{
			return context.BolosDocesBemCasados.ToList();
		}
	}
}
