using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class SomIluminacao : DataAccessBase<Model.SomIluminacao>
	{
		public override void Update(Model.SomIluminacao entity)
		{
			Model.SomIluminacao original = context.SonsIluminacoes.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.SomIluminacao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.SomIluminacao entity)
		{
			context.SonsIluminacoes.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.SomIluminacao> GetCollection()
		{
			return context.SonsIluminacoes.ToList();
		}
	}
}
