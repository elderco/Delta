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
            Data.Context context = new Data.Context();
            Model.Perfil original = context.Perfil.FirstOrDefault(s => s.Id == entity.Id);
            context.Perfil.Remove(original);
            context.Perfil.Add(new Model.Perfil 
            {
                Id = entity.Id,
                Modulos = entity.Modulos,
                Nome = entity.Nome
            });
            context.SaveChanges();
        }
    }
}
