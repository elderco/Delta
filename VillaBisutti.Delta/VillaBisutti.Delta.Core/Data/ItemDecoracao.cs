using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemDecoracao : DataAccessBase<Model.ItemDecoracao>
	{
		public override void Update(Model.ItemDecoracao entity)
		{
			Model.ItemDecoracao original = context.ItemDecoracao.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemDecoracao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemDecoracao entity)
		{
			context.ItemDecoracao.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemDecoracao> GetCollection()
		{
			return context.ItemDecoracao.Include(id => id.TipoItemDecoracao).ToList();
		}
		public List<Model.ItemDecoracao> ListarPorTipo(int tipoId)
		{
			return context.ItemDecoracao.Where(m => m.TipoItemDecoracaoId == tipoId).ToList();
		}
		public List<Model.ItemDecoracao> Filtrar(int tipoId, string str)
		{
			List<Model.ItemDecoracao> retorno = context.ItemDecoracao.Include(m => m.TipoItemDecoracao)
				.Where(item => (item.TipoItemDecoracaoId == tipoId || tipoId == 0)
					&& (item.Nome.ToLower().Replace(str, "") != item.Nome.ToLower() || str == string.Empty))
				.ToList();
			return retorno;
		}
	}
}
