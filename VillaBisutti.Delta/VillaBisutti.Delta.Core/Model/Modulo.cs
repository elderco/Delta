using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Modulo : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public String URL { get; set; }
		public List<PerfilModulo> PerfilModulo { get; set; }
		[NotMapped]
		public string[] Urls
		{
			get
			{
				return URL.Split('|');
			}
		}
	}
}
