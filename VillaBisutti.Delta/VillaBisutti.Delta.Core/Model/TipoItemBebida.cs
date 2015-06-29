using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoItemBebida : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<ItemBebida> Itens { get; set; }
		[Display(Name = "Item padrão para Aniversario")]
		public bool PadraoAniversario { get; set; }
		[Display(Name = "Item padrão para Barmitzva")]
		public bool PadraoBarmitzva { get; set; }
		[Display(Name = "Item padrão para Batmitzva")]
		public bool PadraoBatmitzva { get; set; }
		[Display(Name = "Item padrão para Casamento")]
		public bool PadraoCasamento { get; set; }
		[Display(Name = "Item padrão para Corporativo")]
		public bool PadraoCorporativo { get; set; }
		[Display(Name = "Tipo padrão para Debutante")]
		public bool PadraoDebutante { get; set; }
		[Display(Name = "Tipo deve ser criado junto com eventro do tipo Outro")]
		public bool PadraoOutro { get; set; }
	}
}
