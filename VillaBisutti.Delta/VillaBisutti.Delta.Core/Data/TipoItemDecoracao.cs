using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemDecoracao : DataAccessBase<Model.TipoItemDecoracao>
	{
		public override void Update(Model.TipoItemDecoracao entity)
		{
			Model.TipoItemDecoracao original = context.TiposItensDecoracoes.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemDecoracao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemDecoracao entity)
		{
			context.TiposItensDecoracoes.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemDecoracao> GetCollection()
		{
			return context.TiposItensDecoracoes.ToList();
		}
	}
}
