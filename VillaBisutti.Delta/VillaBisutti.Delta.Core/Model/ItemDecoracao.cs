using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemDecoracao : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Decoração"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 161)]
		public int Quantidade { get; set; }
		[Display(Name = "Decoração")]
		public int TipoItemDecoracaoId { get; set; }
		[Display(Name = "Decoração")]
		public TipoItemDecoracao TipoItemDecoracao { get; set; }
	}
}
