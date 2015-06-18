using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Decoracao : DataAccessBase<Model.Decoracao>
	{
		public override void Update(Model.Decoracao entity)
		{
			Model.Decoracao original = context.Decoracoes.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Decoracao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Decoracao entity)
		{
			context.Decoracoes.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Decoracao> GetCollection()
		{
			return context.Decoracoes.ToList();
		}
	}
}
