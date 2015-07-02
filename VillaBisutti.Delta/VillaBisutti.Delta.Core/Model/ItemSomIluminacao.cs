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
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade")]
		public int Quantidade { get; set; }
		public int TipoItemSomIluminacaoId { get; set; }
		[Display(Name = "Som e de Iluminação")]
		public TipoItemSomIluminacao TipoItemSomIluminacao { get; set; }
	}
}
