using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Foto : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "URL da imagem"), Required]
		public string URL { get; set; }
		[Display(Name = "Legenda")]
		public string Legenda { get; set; }
		public string Qual { get; set; }
		public int EventoId { get; set; }
	}
}
