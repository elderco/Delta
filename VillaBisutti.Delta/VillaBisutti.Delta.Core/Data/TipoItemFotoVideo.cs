using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemFotoVideo : DataAccessBase<Model.TipoItemFotoVideo>
	{
		public override void Update(Model.TipoItemFotoVideo entity)
		{
			Model.TipoItemFotoVideo original = context.TiposItensFotosVideos.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemFotoVideo entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemFotoVideo entity)
		{
			context.TiposItensFotosVideos.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemFotoVideo> GetCollection()
		{
			return context.TiposItensFotosVideos.ToList();
		}
	}
}
