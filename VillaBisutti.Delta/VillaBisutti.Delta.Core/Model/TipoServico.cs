using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoServico : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
	}
}
