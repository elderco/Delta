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
			//Método para bloquear ou não os forms
			bool somenteLeitura = false;
			Dictionary<string, string> dic = new Dictionary<string, string>();

			List<model.Modulo> modulos = new data.Usuario().EntireUser(usuario.Id).Perfil.Modulos.Select(a => a.Modulo).ToList();
			List<model.PerfilModulo> perfilModulo = new data.Usuario().EntireUser(usuario.Id).Perfil.Modulos;
			foreach (var item in modulos)
			{
				if (!string.IsNullOrEmpty(item.URL))
				{
					dic[item.Nome] = item.URL; 
				}
			}
			foreach (var item in dic)
			{
				//bool podeLer = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.Where(x => x.Value.Equals(item)).FirstOrDefault().Key)).Select(a => a.PodeLer).FirstOrDefault();
				//bool podeAlterar = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Equals(item)).Key)).Select(a => a.PodeAlterar).FirstOrDefault();
				string[] itemSplitted = item.Value.Split('|');
				//pega a Url completa que veio do parametro, pois pode ser que so naquele controller e action ele tem ou não acesso
				if (itemSplitted.Contains(url))
				{
					bool podeLer = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Contains(item.Value.ToString())).Key)).Select(a => a.PodeLer).SingleOrDefault();
					bool podeAlterar = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Contains(item.Value.ToString())).Key)).Select(a => a.PodeAlterar).SingleOrDefault();
					if (podeLer == true && podeAlterar == false)
					{
						somenteLeitura = true;
					}
					else
						somenteLeitura = false;
				}
				else //neste caso o cara não tem acesso em nenhuma action do respectivo controller
				{
					string novaUrl = url.Substring(1).Split('/')[0];
					if (itemSplitted.Contains(novaUrl))
					{
						bool podeLer = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Equals(item.Value.ToString())).Key)).Select(a => a.PodeLer).SingleOrDefault();
						bool podeAlterar = perfilModulo.Where(a => a.Modulo.Nome.Equals(dic.FirstOrDefault(x => x.Value.Equals(item.Value.ToString())).Key)).Select(a => a.PodeAlterar).SingleOrDefault();
						//Esta logica é para pegar o valor do atribulo pode 
						if (podeLer == true && podeAlterar == false)
						{
							somenteLeitura = true;
						}
						else
							somenteLeitura = false;
					}
				}
			}
			
			//foreach (string item in modulos)
			//{
			//	string[] moduloSplitado = item.Split('|');
			//	string[] novaUrl = url.Substring(1).Replace('/', ' ').Split(' ');
			//	if (moduloSplitado.Contains(url))
			//	{
			//		somenteLeitura = VericaPermissaoSomenteLeitura(usuario, somenteLeitura);
			//	}
			//	else if (moduloSplitado.Contains(novaUrl[0]))
			//	{
			//		somenteLeitura = VericaPermissaoSomenteLeitura(usuario, somenteLeitura);
			//	}
			//	else
			//		somenteLeitura = true;
			//}
			return somenteLeitura;
		}

		private bool VericaPermissaoSomenteLeitura(model.Usuario usuario, bool somenteLeitura)
		{
			if (new data.Usuario().EntireUser(usuario.Id).Perfil.Modulos.Select(a => a.PodeLer).FirstOrDefault() == true && new data.Usuario().EntireUser(usuario.Id).Perfil.Modulos.Select(a => a.PodeAlterar).FirstOrDefault() == false)
			{
				somenteLeitura = true;
			}
			else
			{
				somenteLeitura = false;
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
			bool podeLer = false;
			List<string> modulos = new data.Usuario().EntireUser(usuario.Id).Perfil.Modulos.Select(a => a.Modulo.URL).ToList();
			foreach (string item in modulos)
			{
				string[] moduloSplitado = item.Split('|');
				string[] novaUrl = url.Substring(1).Replace('/', ' ').Split(' ');
				if (moduloSplitado.Contains(url))
				{
					podeLer = VericaPermissaoLeitura(usuario, podeLer);
				}
				else if (moduloSplitado.Contains(novaUrl[0]))
				{
					podeLer = VericaPermissaoLeitura(usuario, podeLer);
				}
				else
					return podeLer;
			}
			
			return podeLer;
		}

		private static bool VericaPermissaoLeitura(model.Usuario usuario, bool podeLer)
		{
			if (new data.Usuario().EntireUser(usuario.Id).Perfil.Modulos.Select(a => a.PodeLer).FirstOrDefault() == true)
			{
				podeLer = true;
			}
			else
			{
				podeLer = false;
			}
			return podeLer;
		}
    }
}
