using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemFormaBoloDoceBemCasado : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int FornecedorId { get; set; }
		public FornecedorBoloDoceBemCasado Fornecedor { get; set; }
	}
}
