using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemBebida : DataAccessBase<Model.TipoItemBebida>
	{
		public override void Update(Model.TipoItemBebida entity)
		{
			//context.TipoItemBebida.Attach(entity);
			//context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
			//context.SaveChanges();
			Model.TipoItemBebida original = context.TipoItemBebida.Find(entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}
		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemBebida entity)
		{
			return context.Entry(entity);
		}
		public override void Insert(Model.TipoItemBebida entity)
		{
			context.TipoItemBebida.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemBebida> GetCollection()
		{
			return context.TipoItemBebida.ToList();
		}
	}
}
