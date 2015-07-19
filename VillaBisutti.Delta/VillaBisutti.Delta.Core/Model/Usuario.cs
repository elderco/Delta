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
		[Required]
		public string Nome { get; set; }
		[Display(Name = "E-mail"), Required]
		public string Email { get; set; }
		[Display(Name = "Senha"), Required]
		public string Senha{ get; set; }
		public int PerfilId { get; set; }
		public Perfil Perfil { get; set; }
	}
}
