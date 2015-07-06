using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class FornecedorBoloDoceBemCasado : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome do fornecedor"), Required]
		public string NomeFornecedor { get; set; }
		[Display(Name = "Doces Fornecidos")]
		public List<ItemBoloDoceBemCasado> DocesFornecidos { get; set; }
		[Display(Name = "Formas Fornecidos")]
		public List<ItemFormaBoloDoceBemCasado> FormasFornecidos { get; set; }
	}
}
