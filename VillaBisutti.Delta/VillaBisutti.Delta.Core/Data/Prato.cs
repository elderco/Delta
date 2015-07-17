using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
    public class Prato : DataAccessBase<Model.Prato>
    {
        public override void Update(Model.Prato entity)
        {
            Model.Prato original = context.Prato.FirstOrDefault(x => x.Id.Equals(entity.Id));
            context.Entry(original).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Prato entity)
        {
            return context.Entry(entity);
        }

        public override void Insert(Model.Prato entity)
        {
            context.Prato.Add(entity);
			context.SaveChanges();
		}
		protected override List<Model.Prato> GetCollection()
		{
			return context.Prato.Include(i => i.TipoPrato).ToList();
		}
		public List<Model.Prato> GetFromTipo(int tipoId)
		{
			return context.Prato.Include(i => i.TipoPrato).Where(
				(i => i.TipoPratoId == tipoId || tipoId == 0)
				).ToList();
		}
		public List<Model.Prato> ListarPorTipo(int tipoId)
        {
			return context.Prato.Where(ib => ib.TipoPratoId == tipoId).ToList();
        }
		public List<Model.Prato> Filtrar(int tipoId, string str)
		{
			List<Model.Prato> retorno = context.Prato.Include(m => m.TipoPrato)
				.Where(item => (item.TipoPratoId == tipoId || tipoId == 0)
					&& (item.Nome.ToLower().Replace(str, "") != item.Nome.ToLower() || str == string.Empty))
				.ToList();
			return retorno;
		}
    }
}
