using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Evento : DataAccessBase<Model.Evento>
	{
		public override void Update(Model.Evento entity)
		{
			Model.Evento original = context.Evento.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Evento entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Evento entity)
		{
			context.Evento.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Evento> GetCollection()
		{
			return context.Evento.ToList();
		}
		public List<Model.Evento> GetEventos(int casaId, int produtorId)
		{
			return context.Evento.Where(e => 
				e.LocalId == casaId && e.ProdutoraId == produtorId
				).ToList();
		}
	}
}
