using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemGastronomiaSelecionado : DataAccessBase<Model.ItemGastronomiaSelecionado>
	{
		public override void Update(Model.ItemGastronomiaSelecionado entity)
		{
			Model.ItemGastronomiaSelecionado original = context.Gastronomia.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemGastronomiaSelecionado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemGastronomiaSelecionado entity)
		{
			context.Gastronomia.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemGastronomiaSelecionado> GetCollection()
		{
			return context.Gastronomia.ToList();
		}
	}
}
