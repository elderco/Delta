using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemBebida : DataAccessBase<Model.ItemBebida>
	{
		public override void Update(Model.ItemBebida entity)
		{
			Model.ItemBebida original = context.ItemBebida.FirstOrDefault(b => b.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override DbEntityEntry GetCurrent(Model.ItemBebida entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemBebida entity)
		{
			context.ItemBebida.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemBebida> GetCollection()
		{
			return context.ItemBebida.ToList();
		}
	}
}
