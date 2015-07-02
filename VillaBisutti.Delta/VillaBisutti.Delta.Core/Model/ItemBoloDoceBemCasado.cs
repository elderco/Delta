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
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 161)]
		public int Quantidade { get; set; }
		public int TipoItemBoloDoceBemCasadoId { get; set; }
		[Display(Name = "Bolo, Doce e Bem Casado")]
		public TipoItemBoloDoceBemCasado TipoItemBoloDoceBemCasado { get; set; }
	}
}
