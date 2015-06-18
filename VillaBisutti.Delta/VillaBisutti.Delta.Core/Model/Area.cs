using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Area : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<TipoItemBoloDoceBemCasado> TipoDocesExibir { get; set; }
		public List<TipoItemDecoracao> TipoDecoracaoExibir { get; set; }
		public List<TipoItemFotoVideo> TipoFotoExibir { get; set; }
		public List<TipoItemGastronomia> TipoGastronomiaExibir { get; set; }
		public List<TipoItemMontagem> TipoMontagemExibir { get; set; }
		public List<TipoItemOutroItem> TipoOutrosExibir { get; set; }
		public List<TipoItemSomIluminacao> TipoSomExibir { get; set; }
	}
}
