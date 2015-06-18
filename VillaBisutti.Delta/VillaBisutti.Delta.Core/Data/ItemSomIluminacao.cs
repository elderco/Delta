using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemSomIluminacao : DataAccessBase<Model.ItemSomIluminacao>
	{
		public override void Update(Model.ItemSomIluminacao entity)
		{
			Model.ItemSomIluminacao original = context.ItemSomIluminacao.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemSomIluminacao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemSomIluminacao entity)
		{
			context.ItemSomIluminacao.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemSomIluminacao> GetCollection()
		{
			return context.ItemSomIluminacao.ToList();
		}
	}
}
