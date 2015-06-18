using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemOutroItemItemDiverso : DataAccessBase<Model.TipoItemOutroItem>
	{
		public override void Update(Model.TipoItemOutroItem entity)
		{
			Model.TipoItemOutroItem original = context.TipoItemOutroItem.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemOutroItem entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemOutroItem entity)
		{
			context.TipoItemOutroItem.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemOutroItem> GetCollection()
		{
			return context.TipoItemOutroItem.ToList();
		}
	}
}
