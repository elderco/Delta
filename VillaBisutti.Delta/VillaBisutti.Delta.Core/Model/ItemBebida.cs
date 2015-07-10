using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemBebida : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 9999999)]
		public int Quantidade { get; set; }
		public int TipoItemBebidaId { get; set; }
		[Display(Name = "Bebida")]
		public TipoItemBebida TipoItemBebida { get; set; }
	}
}
