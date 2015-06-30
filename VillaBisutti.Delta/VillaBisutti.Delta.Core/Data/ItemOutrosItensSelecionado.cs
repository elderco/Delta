using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ItemOutrosItensSelecionado : DataAccessBase<Model.OutrosItens>
	{
        public override void Update(Model.OutrosItens entity)
		{
            Model.OutrosItens original = context.OutrosItens.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

        public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.OutrosItens entity)
		{
			return context.Entry(entity);
		}

        public override void Insert(Model.OutrosItens entity)
		{
            context.OutrosItens.Add(entity);
			context.SaveChanges();
		}

        protected override List<Model.OutrosItens> GetCollection()
		{
            return context.OutrosItens.ToList();
		}
	}
}
