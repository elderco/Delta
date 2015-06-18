using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemBoloDoceBemCasado : DataAccessBase<Model.TipoItemBoloDoceBemCasado>
	{
		public override void Update(Model.TipoItemBoloDoceBemCasado entity)
		{
			Model.TipoItemBoloDoceBemCasado original = context.TipoItemBoloDoceBemCasado.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemBoloDoceBemCasado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemBoloDoceBemCasado entity)
		{
			context.TipoItemBoloDoceBemCasado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemBoloDoceBemCasado> GetCollection()
		{
			return context.TipoItemBoloDoceBemCasado.ToList();
		}
	}
}
