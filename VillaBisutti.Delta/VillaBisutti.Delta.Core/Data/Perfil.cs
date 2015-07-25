using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class Perfil : DataAccessBase<Model.Perfil>
	{
		public override void Update(Model.Perfil entity)
		{
			Model.Perfil original = context.Perfil.FirstOrDefault(s => s.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Perfil entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Perfil entity)
		{
			context.Perfil.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Perfil> GetCollection()
		{
			return context.Perfil.ToList();
		}

        public Model.Perfil GetContextPerfil(int id)
        {
            List<Model.PerfilModulo> modePerfil = (from perfil in context.Perfil.ToList()
                                                   join perfilModulo in context.PerfilModulo.ToList()
                                                       on perfil.Id equals perfilModulo.PerfilId
                                                   where perfil.Id == id
                                                   select perfilModulo).ToList();

            Model.Perfil perfis = context.Perfil.SingleOrDefault(a => a.Id == id);
            perfis.Modulos = modePerfil;
            return perfis;
            
        }

        public List<Model.Usuario> Filtrar(int tipoId, string texto)
        {
            IEnumerable<Model.Usuario> retorno = context.Usuario.Include(m => m.PerfilId)
                .Where(item => item.PerfilId == tipoId || tipoId == 0);
            return retorno.ToList();
        }
    }
}
