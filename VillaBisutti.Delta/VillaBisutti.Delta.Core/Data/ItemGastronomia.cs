using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemGastronomia : DataAccessBase<Model.ItemGastronomia>
	{
		public override void Update(Model.ItemGastronomia entity)
		{
			Model.ItemGastronomia original = context.ItensGastronomias.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemGastronomia entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemGastronomia entity)
		{
			context.ItensGastronomias.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemGastronomia> GetCollection()
		{
			return context.ItensGastronomias.ToList();
		}
	}
}
