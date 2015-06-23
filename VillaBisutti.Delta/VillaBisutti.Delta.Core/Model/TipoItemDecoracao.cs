using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoItemDecoracao : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<ItemDecoracao> Itens { get; set; }
		[Description("Item deve ser criado junto com evento do tipo Aniversario")]
		public bool PadraoAniversario { get; set; }
		[Description("Item deve ser criado junto com evento do tipo Barmitzva")]
		public bool PadraoBarmitzva { get; set; }
		[Description("Item deve ser criado junto com evento do tipo Batmitzva")]
		public bool PadraoBatmitzva { get; set; }
		[Description("Item deve ser criado junto com evento do tipo Casamento")]
		public bool PadraoCasamento { get; set; }
		[Description("Item deve ser criado junto com evento do tipo Corporativo")]
		public bool PadraoCorporativo { get; set; }
		[Description("Tipo deve ser criado junto com evento do tipo Debutante")]
		public bool PadraoDebutante { get; set; }
		[Description("Tipo deve ser criado junto com eventro do tipo Outro")]
		public bool PadraoOutro { get; set; }
	}
}
