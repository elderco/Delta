using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemBoloDoceBemCasadoSelecionado : DataAccessBase<Model.ItemBoloDoceBemCasadoSelecionado>
	{
		public override void Update(Model.ItemBoloDoceBemCasadoSelecionado entity)
		{
			Model.ItemBoloDoceBemCasadoSelecionado original = context.ItemBoloDoceBemCasadoSelecionado.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemBoloDoceBemCasadoSelecionado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemBoloDoceBemCasadoSelecionado entity)
		{
			context.ItemBoloDoceBemCasadoSelecionado.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemBoloDoceBemCasadoSelecionado> GetCollection()
		{
			return context.ItemBoloDoceBemCasadoSelecionado.ToList();
		}
	}
}
