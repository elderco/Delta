using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
    public class PerfilAlterado
    {
        public void AlterarPerfil(Model.Perfil entity)
        {
			Model.Perfil original = Util.context.Perfil.FirstOrDefault(s => s.Id == entity.Id);
			Util.context.Perfil.Remove(original);
			Util.context.Perfil.Add(new Model.Perfil 
            {
                Id = entity.Id,
                Modulos = entity.Modulos,
                Nome = entity.Nome
            });
			Util.context.SaveChanges();
        }
    }
}
