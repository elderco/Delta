using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
	public class Cardapio
	{
		public Data.Context context { 
			get 
			{
				return Util.context;
			}
		}
		public Cardapio() { }
		public void CriarCardapio(Model.Cardapio cardapio)
		{
			context.Cardapio.Add(cardapio);
			context.SaveChanges();
			List<Model.TipoPratoPadrao> tpp = new List<Model.TipoPratoPadrao>();
			foreach (Model.TipoPrato tipoPrato in context.TipoPrato.ToList())
				foreach (Model.TipoServico tipoServico in context.TipoServico.ToList())
					tpp.Add(new Model.TipoPratoPadrao { TipoPratoId = tipoPrato.Id, TipoServicoId = tipoServico.Id, CardapioId = cardapio.Id, QuantidadePratos = 1 });
			context.TipoPratoPadrao.AddRange(tpp);
			context.SaveChanges();
		}
	}
	public class TipoPrato
	{
		public Data.Context context { 
			get 
			{
				return Util.context;
			}
		}
		public TipoPrato() { }
		public void CriarTipoPrato(Model.TipoPrato tipoPrato)
		{
			context.TipoPrato.Add(tipoPrato);
			context.SaveChanges();
			List<Model.TipoPratoPadrao> tpp = new List<Model.TipoPratoPadrao>();
			foreach(Model.Cardapio cardapio in context.Cardapio.ToList())
				foreach (Model.TipoServico tipoServico in context.TipoServico.ToList())
					tpp.Add(new Model.TipoPratoPadrao { TipoPratoId = tipoPrato.Id, TipoServicoId = tipoServico.Id, CardapioId = cardapio.Id, QuantidadePratos = 1 });
			context.TipoPratoPadrao.AddRange(tpp);
			context.SaveChanges();
		}
	}
}
