using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class SomIluminacao : DataAccessBase<Model.ItemSomIluminacaoSelecionado>
	{
		public override void Update(Model.ItemSomIluminacaoSelecionado entity)
		{
			Model.ItemSomIluminacaoSelecionado original = context.SonsIluminacoes.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemSomIluminacaoSelecionado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemSomIluminacaoSelecionado entity)
		{
			context.SonsIluminacoes.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemSomIluminacaoSelecionado> GetCollection()
		{
			return context.SonsIluminacoes.ToList();
		}
	}
}
