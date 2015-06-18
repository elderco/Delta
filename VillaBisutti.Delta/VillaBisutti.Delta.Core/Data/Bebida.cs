using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemBebidaSelecionado : DataAccessBase<Model.ItemBebidaSelecionado>
	{

		public override void Update(Model.ItemBebidaSelecionado entity)
		{
			Model.ItemBebidaSelecionado original = context.ItemBebidaSelecionado.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemBebidaSelecionado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemBebidaSelecionado entity)
		{
			context.ItemBebidaSelecionado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemBebidaSelecionado> GetCollection()
		{
			return context.ItemBebidaSelecionado.ToList();
		}
	}
}
