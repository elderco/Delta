using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Usuario : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha{ get; set; }
		public int PerfilUsuarioSistemaId { get; set; }
		public PerfilUsuarioSistema Perfil { get; set; }
		public List<Evento> EventosProdutora { get; set; }
	}
}
