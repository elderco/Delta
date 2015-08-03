using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
    public class Perfil
    {
        public void AlterarPerfil(Model.Perfil entity)
        {
			Model.Perfil perfil = Util.context.Perfil.Where(a => a.Id == entity.Id).FirstOrDefault();
			int id = perfil.Modulos.Select(m => m.PerfilId).FirstOrDefault();
			Model.Usuario usuario = Util.context.Usuario.Where(u => u.PerfilId == id).FirstOrDefault();
			Util.context.Perfil.Remove(perfil);
			Util.context.Perfil.Add(new Model.Perfil
			{
				Id = entity.Id,
				Modulos = entity.Modulos,
				Nome = entity.Nome

			});
			Util.context.SaveChanges();
			
        }

		public void RemoverPerfil(int Id)
		{
			Model.Perfil perfilRemovido = Util.context.Perfil.FirstOrDefault(s => s.Id == Id);
			Util.context.Perfil.Remove(perfilRemovido);
			Util.context.SaveChanges();
		}
    }
}
