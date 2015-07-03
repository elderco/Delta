using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemOutrosItens : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 161)]
		public int Quantidade { get; set; }
		public int TipoItemOutrosItensId { get; set; }
		[Display(Name = "Outros Itens")]
		public TipoItemOutrosItens TipoItemOutrosItens { get; set; }
	}
}
