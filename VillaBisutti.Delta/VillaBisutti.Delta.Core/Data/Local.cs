using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Local : DataAccessBase<Model.Local>
	{
		public override void Update(Model.Local entity)
		{
			Model.Local original = context.Local.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Local entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Local entity)
		{
			context.Local.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Local> GetCollection()
		{
			return context.Local.ToList();
		}
	}
}
