using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Business
{
    public class Perfil
    {
		public void RemoverPerfil(int Id)
		{
			Model.Perfil perfilRemovido = Util.context.Perfil.FirstOrDefault(s => s.Id == Id);
			Util.context.Perfil.Remove(perfilRemovido);
			Util.context.SaveChanges();
		}
    }
}
