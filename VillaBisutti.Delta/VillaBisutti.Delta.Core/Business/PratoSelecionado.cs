using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Business
{
	public class PratoSelecionado
	{
		public void ImportarPratosDosCardapios()
		{
			Data.Context context = new Data.Context();
			foreach (Model.Cardapio cardapio in context.Cardapio.Include(c => c.Pratos).ToList())
				foreach (Model.TipoServico tipoServico in Util.TiposServico.Keys)
					foreach(Model.Prato prato in cardapio.Pratos)
					context.PratoSelecionado.Add(new Model.PratoSelecionado {
						PratoId = prato.Id,
						CardapioId = cardapio.Id,
						TipoServico = tipoServico,
						Degustar = true,
						Escolhido = false
					});
		}
	}
}
