using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class PerfilUsuarioSistema : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		public int TipoAcessoId { get; set; }
		public TipoAcesso TipoAcesso
		{
			get
			{
				return (TipoAcesso)TipoAcessoId;
			}
			set
			{
				TipoAcessoId = (int)value;
			}
		}
		public List<Usuario> Usuarios { get; set; }
	}
}
