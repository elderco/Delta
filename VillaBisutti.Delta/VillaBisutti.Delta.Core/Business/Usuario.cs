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
        /// Veririca se o acesso é somente leitura
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool SomenteLeitura(model.Usuario usuario, string url)
		{
			bool somenteLeitura = false;
			Dictionary<string, string> dic = new Dictionary<string, string>();
            List<model.Modulo> modulos = usuario.Perfil.Modulos.Select(a => a.Modulo).ToList();
            List<model.PerfilModulo> perfilModulo = usuario.Perfil.Modulos;
            foreach (var item in modulos)
            {
                if (!string.IsNullOrEmpty(item.URL))
                {
                    dic[item.Nome] = item.URL;
                }
            }
            foreach (var item in dic)
            {
                string[] itemSplitted = item.Value.Split('|');
                bool podeLer = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Contains(item.Value.ToString())).Key)).Select(a => a.PodeLer).SingleOrDefault();
                bool podeAlterar = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Contains(item.Value.ToString())).Key)).Select(a => a.PodeAlterar).SingleOrDefault();
                if (itemSplitted.Contains(url))
                {
                    if (podeLer == true && podeAlterar == false)
                    {
                        somenteLeitura = true;
                    }
                    else
                        somenteLeitura = false;
                }
                else
                {
                    string novaUrl = url.Substring(1).Split('/')[0];
                    if (itemSplitted.Contains(novaUrl))
                    {
                        if (podeLer == true && podeAlterar == false)
                        {
                            somenteLeitura = true;
                        }
                        else if (podeLer == false && podeAlterar == false)
                        {
                            //TODO: ver o que fazer para quando cair na tela 
                        }
                        else
                        {
                            somenteLeitura = false;
                        } 
                    }
                }
            }
            return somenteLeitura;
		}

        /// <summary>
        /// Verifica se o usuario pode ler. Este é para o caso de aparecer ou não os botões
        /// </summary>
        /// <param name="?"></param>
        /// <param name="url"></param>
        /// <returns></returns>
		public bool PodeLer(model.Usuario usuario, string url)
		{
			//Este método retorna apenas para os casos de aparecer ou não os botões. Independe saber se tem acesso total ou não
			//TODO: tirar
			return true;
            bool ler = false;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (usuario != null)
            {
                List<model.Modulo> modulos = usuario.Perfil.Modulos.Select(a => a.Modulo).ToList();
                List<model.PerfilModulo> perfilModulo = usuario.Perfil.Modulos;
                bool podeLer = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Contains(item.Value.ToString())).Key)).Select(a => a.PodeLer).SingleOrDefault();
                foreach (var item in modulos)
                {
                    if (!string.IsNullOrEmpty(item.URL))
                    {
                        dic[item.Nome] = item.URL;
                    }
                }
                foreach (var item in dic)
                {
                    string[] itemSplitted = item.Value.Split('|');
                    if (itemSplitted.Contains(url))
                    {
                        return podeLer;
                    }
                    else
                    {
                        string novaUrl = url.Substring(1).Split('/')[0];
                        if (itemSplitted.Contains(novaUrl))
                        {
                            return podeLer;
                        }
                    } 
                }
            }

            return ler;
		}

    }
}
