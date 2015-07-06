using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Data
{
	public class SampleData : DropCreateDatabaseIfModelChanges<Context>
	{
		protected override void Seed(Context context)
		{
			context.Local.Add(new Model.Local { SiglaCasa = "CA", NomeCasa = "Casa do Ator", EnderecoCasa = "Rua Casa do Ator, 642" });
			context.Local.Add(new Model.Local { SiglaCasa = "BE", NomeCasa = "Berrini", EnderecoCasa = "R. James Joule, 40" });
			context.Local.Add(new Model.Local { SiglaCasa = "GC", NomeCasa = "Gomes de Carvalho", EnderecoCasa = "R. Gomes de carvalho, 420" });
			context.Local.Add(new Model.Local { SiglaCasa = "QT", NomeCasa = "Quatá", EnderecoCasa = "R. Quatá, 567" });
			context.Local.Add(new Model.Local { SiglaCasa = "T", NomeCasa = "Tenerife", EnderecoCasa = "R. Tenerife, 140" });
			context.Local.Add(new Model.Local { SiglaCasa = "011", NomeCasa = "011 eventos", EnderecoCasa = "R. Alvorada, 180" });
			context.SaveChanges();

			context.Prato.Add(new Model.Prato { Nome = "Coquetel de Camarão com molho Tarê" });
			context.Prato.Add(new Model.Prato { Nome = "Mini robata de berinjela com queijo de mussarela de bufala e tomate seco" });
			context.Prato.Add(new Model.Prato { Nome = "Mini batata cozida com molho de gorgonzola" });
			context.Prato.Add(new Model.Prato { Nome = "Canapé de ervas finas e kanikama em cestinha crocante" });
			context.Prato.Add(new Model.Prato { Nome = "Mini burguer de filet mignon com sour cream de iogurte" });
			context.Prato.Add(new Model.Prato { Nome = "Mini quiche alho poró com shimeji" });
			context.Prato.Add(new Model.Prato { Nome = "Blini de banana da terra, carne seca e crispy de couve" });
			context.Prato.Add(new Model.Prato { Nome = "Mini bruschetta à moda caprese (mussarela de búfala, tomate casse e manjericão)" });
			context.Prato.Add(new Model.Prato { Nome = "Croquete de bobó de camarão" });
			context.Prato.Add(new Model.Prato { Nome = "Voul al Vent de queijo brie com pistache e mel" });
			context.Prato.Add(new Model.Prato { Nome = "Mini Escondidinho de siri com purê de mandioca e queijo coalho" });
			context.Prato.Add(new Model.Prato { Nome = "Mini polenta com cordero e redução de aceto" });
			context.Prato.Add(new Model.Prato { Nome = "Salada nobre de folhas verdes com lascas de parmesão, croutons e nozes ao molho de mostarda e mel" });
			context.Prato.Add(new Model.Prato { Nome = "Ravioli de Ementhal com limão siciliano" });
			context.Prato.Add(new Model.Prato { Nome = "Medalhão de fillet ao molho de vinho madeira e azeite aromatizado" });
			context.Prato.Add(new Model.Prato { Nome = "Salmão ao molho de alcaparras" });
			context.Prato.Add(new Model.Prato { Nome = "Legumes ao gratin" });
			context.Prato.Add(new Model.Prato { Nome = "Risoto de aspargos frescos" });
			context.Prato.Add(new Model.Prato { Nome = "Frutas in natura" });
			context.Prato.Add(new Model.Prato { Nome = "Lasanha de chocolate com sorvete de creme" });
			context.Prato.Add(new Model.Prato { Nome = "Cheese Cake com calda de Frutas Vermelhas" });
			context.SaveChanges();
			List<Model.Prato> pratos = context.Prato.ToList();

			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Coquetel Frio", Pratos = pratos.Where(p => p.Nome.Replace("z", "") == p.Nome).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Coquetel Quente", Pratos = pratos.Where(p => p.Nome.Length < 25).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Finger Food", Pratos = pratos.Where(p => p.Nome.Replace("ba", "") == p.Nome).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Salada", Pratos = pratos.Where(p => p.Nome.Replace("h", "") == p.Nome).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Massa", Pratos = pratos.Where(p => p.Nome.Replace("q", "") == p.Nome).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Carne Vermelha", Pratos = pratos.Where(p => p.Nome.Replace("cr", "") == p.Nome).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Carne Branca", Pratos = pratos.Where(p => p.Nome.Length > 40).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Acompanhamento", Pratos = pratos.Where(p => p.Nome.Replace("mo", "") == p.Nome).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Acompanhamento Carbo", Pratos = pratos.Where(p => p.Nome.Replace("ã", "") == p.Nome).ToList() });
			context.TipoPrato.Add(new Model.TipoPrato { Nome = "Sobremesa", Pratos = pratos.Where(p => p.Nome.Replace("z", "") == p.Nome && p.Nome.Length > 30).ToList() });
			context.SaveChanges();

			context.Cardapio.Add(new Model.Cardapio { Nome = "Amalfi", Pratos = pratos.Where(p => p.Nome.Length > 40).ToList() });
			context.Cardapio.Add(new Model.Cardapio { Nome = "Portovenere", Pratos = pratos.Where(p => p.Nome.Replace("mo", "") == p.Nome).ToList() });
			context.SaveChanges();
		}
	}
}
