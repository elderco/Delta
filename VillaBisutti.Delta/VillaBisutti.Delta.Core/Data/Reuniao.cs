using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Reuniao : DataAccessBase<Model.Reuniao>
	{
		//TODO: Implementar os métodos abaixo (Gabriel)
		public override void Update(Model.Reuniao entity)
		{
			Model.Reuniao reuniao = context.Reuniao.FirstOrDefault(s => s.Id.Equals(entity.Id));
			context.Entry(reuniao).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Reuniao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Reuniao entity)
		{
			context.Reuniao.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Reuniao> GetCollection()
		{
			return context.Reuniao.ToList();
		}
	}
}
