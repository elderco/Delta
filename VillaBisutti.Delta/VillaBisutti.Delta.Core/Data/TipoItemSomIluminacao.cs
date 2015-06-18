using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemSomIluminacao : DataAccessBase<Model.TipoItemSomIluminacao>
	{
		public override void Update(Model.TipoItemSomIluminacao entity)
		{
			Model.TipoItemSomIluminacao original = context.TipoItemSomIluminacao.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemSomIluminacao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemSomIluminacao entity)
		{
			context.TipoItemSomIluminacao.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemSomIluminacao> GetCollection()
		{
			return context.TipoItemSomIluminacao.ToList();
		}
	}
}
