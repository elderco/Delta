using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemDecoracaoCerimonial : DataAccessBase<Model.TipoItemDecoracaoCerimonial>
	{
		public override void Update(Model.TipoItemDecoracaoCerimonial entity)
		{
			Model.TipoItemDecoracaoCerimonial original = context.TipoItemDecoracaoCerimonial.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemDecoracaoCerimonial entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemDecoracaoCerimonial entity)
		{
			context.TipoItemDecoracaoCerimonial.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemDecoracaoCerimonial> GetCollection()
		{
			List<Model.TipoItemDecoracaoCerimonial> lista = context.TipoItemDecoracaoCerimonial.ToList();
			lista = lista.OrderBy(ir => ir.Nome).ToList();
			return lista;
		}
	}
}
