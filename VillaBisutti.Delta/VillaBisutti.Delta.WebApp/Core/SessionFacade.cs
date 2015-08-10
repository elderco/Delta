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
				if (value == null)
					return;
				HttpCookie UserCookie = new HttpCookie("UsuarioLogado");
				UserCookie.Expires = DateTime.Now.AddMinutes(60);
				UserCookie.Value = value.Id.ToString();
				HttpContext.Current.Response.SetCookie(UserCookie);
			}
		}
		private static void RenovaCredencialUsuario()
		{
			UsuarioLogado = new Core.Data.Usuario().EntireUser(int.Parse(HttpContext.Current.Request.Cookies["UsuarioLogado"].Value));
		}
		internal static void LogoutUsuario()
		{
			UsuarioLogado = null;
			HttpCookie UserCookie = new HttpCookie("UsuarioLogado");
			UserCookie.Expires = DateTime.Today.AddDays(-1D);
			HttpContext.Current.Response.SetCookie(UserCookie);
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