using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Usuario : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Display(Name = "Senha")]
		public string Senha{ get; set; }
		[Display(Name = "Perfil")]
		public List<TipoAcesso> Perfis { get; set; }
		public List<Evento> EventosProdutora { get; set; }
	}
}
