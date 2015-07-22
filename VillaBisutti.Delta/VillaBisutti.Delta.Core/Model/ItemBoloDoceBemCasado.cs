using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemBoloDoceBemCasado : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Item"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 9999999)]
		public int Quantidade { get; set; }
		public int FornecedorId { get; set; }
		[Display(Name = "Fornecedor")]
		public FornecedorBoloDoceBemCasado Fornecedor { get; set; }
		public int TipoItemBoloDoceBemCasadoId { get; set; }
		public TipoItemBoloDoceBemCasado TipoItemBoloDoceBemCasado { get; set; }
		public bool BloqueiaOutrasPropriedades { get; set; }
	}
}
