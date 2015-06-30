using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VillaBisutti.Delta.Core.Model
{
	public class ItemSomIluminacao : IEntityBase
	{
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public int TipoItemSomIluminacaoId { get; set; }
		public TipoItemSomIluminacao TipoItemSomIluminacao { get; set; }
	}
}
