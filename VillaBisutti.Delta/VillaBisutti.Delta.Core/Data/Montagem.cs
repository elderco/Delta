using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Montagem : DataAccessBase<Model.Montagem>
	{
		public override void Update(Model.Montagem entity)
		{
			Model.Montagem original = context.Montagens.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Montagem entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Montagem entity)
		{
			context.Montagens.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Montagem> GetCollection()
		{
			return context.Montagens.ToList();
		}
	}
}
