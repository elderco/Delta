using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class ContratoAditivo : DataAccessBase<Model.ContratoAditivo>
	{
		public override void Update(Model.ContratoAditivo entity)
		{
			Model.ContratoAditivo original = context.ContratosAdivitivos.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ContratoAditivo entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ContratoAditivo entity)
		{
			context.ContratosAdivitivos.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ContratoAditivo> GetCollection()
		{
			return context.ContratosAdivitivos.ToList();
		}
	}
}
