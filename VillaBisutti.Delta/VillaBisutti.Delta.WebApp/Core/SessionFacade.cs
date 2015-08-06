using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VillaBisutti.Delta.Core.Model;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta
{
	public static class SessionFacade
	{
		public static model.Usuario UsuarioLogado
		{
			get
			{
				if (HttpContext.Current.Session["UsuarioLogado"] == null)
					RenovaCredencialUsuario();
				return (model.Usuario)HttpContext.Current.Session["UsuarioLogado"];
			}
			set
			{
				HttpContext.Current.Session["UsuarioLogado"] = value;
			}
		}
		private static void RenovaCredencialUsuario()
		{
		}
		public static Foto FotoEmMemoria
		{
			get
			{
				return (Foto)HttpContext.Current.Session["FotoEmMemoria"];
			}
			set
			{
				HttpContext.Current.Session["FotoEmMemoria"] = value;
			}
		}
	}
}