using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class FornecedorBoloDoceBemCasado : IEntityBase
	{
		public int Id { get; set; }
		public string NomeFornecedor { get; set; }
		public List<ItemBoloDoceBemCasado> DocesFornecidos { get; set; }
		public List<ItemFormaBoloDoceBemCasado> FormasFornecidos { get; set; }
	}
}
