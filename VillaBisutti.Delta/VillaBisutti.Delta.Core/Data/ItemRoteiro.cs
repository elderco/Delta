using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemRoteiro : DataAccessBase<Model.ItemRoteiro>
	{
		public override void Update(Model.ItemRoteiro entity)
		{
			Model.ItemRoteiro original = context.ItemRoteiro.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}
		public override DbEntityEntry GetCurrent(Model.ItemRoteiro entity)
		{
			return context.Entry(entity);
		}
		public override void Insert(Model.ItemRoteiro entity)
		{
			context.ItemRoteiro.Add(entity);
			context.SaveChanges();
		}
		protected override List<Model.ItemRoteiro> GetCollection()
		{
			return context.ItemRoteiro.Include(p => p.RoteiroPadrao).ToList();
		}
	}
}
