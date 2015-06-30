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
		[Required]
		[Display(Name = "Item")]
		public string Nome { get; set; }
		[Display(Name = "Quantidade disponível")]
		public int Quantidade { get; set; }
		public int TipoItemDecoracaoId { get; set; }
		[Display(Name = "Tipo de Item")]
		public TipoItemDecoracao TipoItemDecoracao { get; set; }
	}
}
