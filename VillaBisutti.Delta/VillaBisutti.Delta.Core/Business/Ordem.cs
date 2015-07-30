using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace VillaBisutti.Delta.Core.Business
{
	public class Ordem
	{
		public void Ordenar(string qual, string order)
		{
			string[] ordem = order.Split(',');
			string[] attributes = {"Ordem"};
			for (int i = 0; i < ordem.Length; i++)
			{
				switch (qual)
				{
					case "DR":	//Decoração da recepção
						Model.TipoItemDecoracao tipoItemDecoracao = Util.context.TipoItemDecoracao.Find(int.Parse(ordem[i]));
						tipoItemDecoracao.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemDecoracao).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemDecoracao).Property(name).IsModified = false;
						Util.context.Entry(tipoItemDecoracao).Property("Ordem").IsModified = true;
						break;
					case "DC":	//Decoração do cerimonial
						Model.TipoItemDecoracaoCerimonial tipoItemDecoracaoCerimonial = Util.context.TipoItemDecoracaoCerimonial.Find(int.Parse(ordem[i]));
						tipoItemDecoracaoCerimonial.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemDecoracaoCerimonial).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemDecoracaoCerimonial).Property(name).IsModified = false;
						Util.context.Entry(tipoItemDecoracaoCerimonial).Property("Ordem").IsModified = true;
						break;
					case "MS":	//Montagem do salão
						Model.TipoItemMontagem tipoItemMontagem = Util.context.TipoItemMontagem.Find(int.Parse(ordem[i]));
						tipoItemMontagem.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemMontagem).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemMontagem).Property(name).IsModified = false;
						Util.context.Entry(tipoItemMontagem).Property("Ordem").IsModified = true;
						break;
					case "GS":	//Gastronomia
						Model.TipoPrato tipoPrato = Util.context.TipoPrato.Find(int.Parse(ordem[i]));
						tipoPrato.Ordem = i;
						foreach(string name in Util.context.Entry(tipoPrato).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoPrato).Property(name).IsModified = false;
						Util.context.Entry(tipoPrato).Property("Ordem").IsModified = true;
						break;
					case "BB":	//Bebidas
						Model.TipoItemBebida tipoItemBebida = Util.context.TipoItemBebida.Find(int.Parse(ordem[i]));
						tipoItemBebida.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemBebida).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemBebida).Property(name).IsModified = false;
						Util.context.Entry(tipoItemBebida).Property("Ordem").IsModified = true;
						break;
					case "BD":	//Bolo, doces e bem-casado
						Model.TipoItemBoloDoceBemCasado tipoItemBoloDoceBemCasado = Util.context.TipoItemBoloDoceBemCasado.Find(int.Parse(ordem[i]));
						tipoItemBoloDoceBemCasado.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemBoloDoceBemCasado).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemBoloDoceBemCasado).Property(name).IsModified = false;
						Util.context.Entry(tipoItemBoloDoceBemCasado).Property("Ordem").IsModified = true;
						break;
					case "FV":	//Foto e vídeo
						Model.TipoItemFotoVideo tipoItemFotoVideo = Util.context.TipoItemFotoVideo.Find(int.Parse(ordem[i]));
						tipoItemFotoVideo.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemFotoVideo).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemFotoVideo).Property(name).IsModified = false;
						Util.context.Entry(tipoItemFotoVideo).Property("Ordem").IsModified = true;
						break;
					case "SI":	//Som e iluminação
						Model.TipoItemSomIluminacao tipoItemSomIluminacao = Util.context.TipoItemSomIluminacao.Find(int.Parse(ordem[i]));
						tipoItemSomIluminacao.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemSomIluminacao).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemSomIluminacao).Property(name).IsModified = false;
						Util.context.Entry(tipoItemSomIluminacao).Property("Ordem").IsModified = true;
						break;
					case "OI":	//Outros itens
						Model.TipoItemOutrosItens tipoItemOutrosItens = Util.context.TipoItemOutrosItens.Find(int.Parse(ordem[i]));
						tipoItemOutrosItens.Ordem = i;
						foreach(string name in Util.context.Entry(tipoItemOutrosItens).CurrentValues.PropertyNames.Except(attributes))
							Util.context.Entry(tipoItemOutrosItens).Property(name).IsModified = false;
						Util.context.Entry(tipoItemOutrosItens).Property("Ordem").IsModified = true;
						break;
				}
			}
			Util.context.SaveChanges();
		}
	}
}
