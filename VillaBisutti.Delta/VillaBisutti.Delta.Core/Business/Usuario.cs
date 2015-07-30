using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.Core.Business
{
    public class Usuario
    {
        /// <summary>
        /// Retorna true/false se o usuário tem perfil para alteração ou não
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool PodeAlterar(model.Usuario usuario, string url)
        {
            
            return false;
        }
        /// <summary>
        /// Retorna true/false se o usuário tem perfil para leitura ou não
        /// </summary>
        /// <param name="?"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool PodeLer(model.Usuario usuario, string url)
        {
            return false;
        }
    }
}
