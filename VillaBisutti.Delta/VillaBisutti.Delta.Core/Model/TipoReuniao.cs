using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoReuniao : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int DiasAntesEvento { get; set; }
		public TipoAcesso AreaEnvolvida { get; set; }
		public List<Reuniao> Reunioes { get; set; }
	}
}
