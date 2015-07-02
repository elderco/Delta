using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemDecoracaoSelecionado : DataAccessBase<Model.ItemDecoracaoSelecionado>
	{
		public override void Update(Model.ItemDecoracaoSelecionado entity)
		{
			Model.ItemDecoracaoSelecionado original = context.ItemDecoracaoSelecionado.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemDecoracaoSelecionado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemDecoracaoSelecionado entity)
		{
			context.ItemDecoracaoSelecionado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemDecoracaoSelecionado> GetCollection()
		{
			return context.ItemDecoracaoSelecionado.ToList();
		}
	}
}
