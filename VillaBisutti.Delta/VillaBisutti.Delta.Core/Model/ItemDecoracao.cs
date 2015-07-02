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
		[Display(Name = "Item"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade disponível"), Range(0, 161)]
		public int Quantidade { get; set; }
		public int TipoItemDecoracaoId { get; set; }
		[Display(Name = "Tipo de Item")]
		public TipoItemDecoracao TipoItemDecoracao { get; set; }
	}
}
