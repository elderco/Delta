using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemOutroItemItemDiverso : DataAccessBase<Model.TipoItemOutrosItens>
	{
		public override void Update(Model.TipoItemOutrosItens entity)
		{
			Model.TipoItemOutrosItens original = context.TipoItemOutrosItens.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemOutrosItens entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemOutrosItens entity)
		{
			context.TipoItemOutrosItens.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemOutrosItens> GetCollection()
		{
			return context.TipoItemOutrosItens.ToList();
		}
	}
}
