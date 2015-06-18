using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class PerfilUsuarioSistema : DataAccessBase<Model.PerfilUsuarioSistema>
	{
		public override void Update(Model.PerfilUsuarioSistema entity)
		{
			Model.PerfilUsuarioSistema original = context.PerfilsUsuariosSistemas.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.PerfilUsuarioSistema entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.PerfilUsuarioSistema entity)
		{
			context.PerfilsUsuariosSistemas.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.PerfilUsuarioSistema> GetCollection()
		{
			return context.PerfilsUsuariosSistemas.ToList();
		}
	}
}

