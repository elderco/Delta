using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Roteiro : DataAccessBase<Model.Roteiro>
	{
		public override void Update(Model.Roteiro entity)
		{
			Model.Roteiro original = context.Roteiro.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Roteiro entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Roteiro entity)
		{
			context.Roteiro.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Roteiro> GetCollection()
		{
			return context.Roteiro.ToList();
		}
	}
}
