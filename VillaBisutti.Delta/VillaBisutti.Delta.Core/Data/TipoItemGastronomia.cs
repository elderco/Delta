using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemGastronomia : DataAccessBase<Model.TipoItemGastronomia>
	{
		public override void Update(Model.TipoItemGastronomia entity)
		{
			Model.TipoItemGastronomia original = context.TipoItemGastronomia.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemGastronomia entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemGastronomia entity)
		{
			context.TipoItemGastronomia.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemGastronomia> GetCollection()
		{
			return context.TipoItemGastronomia.ToList();
		}
	}
}
