using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoServico : DataAccessBase<Model.TipoServico>
	{
		public override void Update(Model.TipoServico entity)
		{
			Model.TipoServico original = context.TipoServico.FirstOrDefault(s => s.Id == (entity.Id));
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoServico entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoServico entity)
		{
			context.TipoServico.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoServico> GetCollection()
		{
			return context.TipoServico.ToList();
		}
	}
}
