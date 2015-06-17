using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemOutroItemItemDiverso : DataAccessBase<Model.TipoItemOutroItemItemDiverso>
	{
		public override void Update(Model.TipoItemOutroItemItemDiverso entity)
		{
			Model.TipoItemOutroItemItemDiverso original = context.TiposItensOutrosItensItensDiversos.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemOutroItemItemDiverso entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemOutroItemItemDiverso entity)
		{
			context.TiposItensOutrosItensItensDiversos.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemOutroItemItemDiverso> GetCollection()
		{
			return context.TiposItensOutrosItensItensDiversos.ToList();
		}
	}
}
