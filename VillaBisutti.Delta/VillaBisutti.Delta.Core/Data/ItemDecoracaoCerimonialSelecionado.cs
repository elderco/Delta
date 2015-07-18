using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemDecoracaoCerimonialSelecionado : DataAccessBase<Model.ItemDecoracaoCerimonialSelecionado>
	{
		public override void Update(Model.ItemDecoracaoCerimonialSelecionado entity)
		{
			Model.ItemDecoracaoCerimonialSelecionado original = context.ItemDecoracaoCerimonialSelecionado.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemDecoracaoCerimonialSelecionado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemDecoracaoCerimonialSelecionado entity)
		{
			context.ItemDecoracaoCerimonialSelecionado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemDecoracaoCerimonialSelecionado> GetCollection()
		{
			return context.ItemDecoracaoCerimonialSelecionado.ToList();
		}
	}
}
