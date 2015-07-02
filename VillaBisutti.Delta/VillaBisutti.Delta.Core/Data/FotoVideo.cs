﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class FotoVideo : DataAccessBase<Model.FotoVideo>
	{
		public override void Update(Model.FotoVideo entity)
		{
			Model.FotoVideo original = context.FotoVideo.FirstOrDefault(s => s.Id == (entity.Id));
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.FotoVideo entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.FotoVideo entity)
		{
			context.FotoVideo.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.FotoVideo> GetCollection()
		{
			return context.FotoVideo.ToList();
		}
	}
}
