using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemFormaBoloDoceBemCasado : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		public int FornecedorId { get; set; }
		[Display(Name = "Fornecedor de Forma")]
		public FornecedorBoloDoceBemCasado Fornecedor { get; set; }
	}
}
