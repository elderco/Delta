using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoEvento : DataAccessBase<Model.TipoEvento>
	{
		public override void Update(Model.TipoEvento entity)
		{
			Model.TipoEvento original = context.TipoEvento.FirstOrDefault(s => s.Id == (entity.Id));
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoEvento entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoEvento entity)
		{
			context.TipoEvento.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoEvento> GetCollection()
		{
			return context.TipoEvento.ToList();
		}
	}
}
