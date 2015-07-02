using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemFotoVideo : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 161)]
		public int Quantidade { get; set; }
		[Display(Name = "Foto Video")]
		public int TipoItemFotoVideoId { get; set; }
		[Display(Name = "Foto Video")]
		public TipoItemFotoVideo TipoItemFotoVideo { get; set; }
	}
}
