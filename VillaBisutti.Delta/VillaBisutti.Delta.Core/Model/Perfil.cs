using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Perfil: IEntityBase
	{
		public int Id { get; set; }
        [Display(Name = "Perfil")]
		public String Nome { get; set; }
		public List<PerfilModulo> Modulos { get; set; }
	}
}
