using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemMontagem : DataAccessBase<Model.ItemMontagem>
	{
		public override void Update(Model.ItemMontagem entity)
		{
			Model.ItemMontagem original = context.ItemMontagem.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemMontagem entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemMontagem entity)
		{
			context.ItemMontagem.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemMontagem> GetCollection()
		{
			return context.ItemMontagem.Include(id => id.TipoItemMontagem).ToList();
		}
	}
}
