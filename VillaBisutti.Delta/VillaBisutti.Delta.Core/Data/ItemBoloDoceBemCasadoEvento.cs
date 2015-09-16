using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemBoloDoceBemCasadoEvento : DataAccessBase<Model.ItemBoloDoceBemCasadoEvento>
	{
		public override void Update(Model.ItemBoloDoceBemCasadoEvento entity)
		{
			Model.ItemBoloDoceBemCasadoEvento original = context.ItemBoloDoceBemCasadoEvento.FirstOrDefault(s => s.Id == (entity.Id));
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemBoloDoceBemCasadoEvento entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemBoloDoceBemCasadoEvento entity)
		{
			context.ItemBoloDoceBemCasadoEvento.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemBoloDoceBemCasadoEvento> GetCollection()
		{
			return context.ItemBoloDoceBemCasadoEvento.ToList();
		}
	}
}
