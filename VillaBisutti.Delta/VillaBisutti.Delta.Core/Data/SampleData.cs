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
			string[] sampleText = { "Ut mollis enim ut erat dictum elementum", "Integer molestie odio in venenatis cursus", "Aliquam hendrerit turpis magna, ut congue est sollicitudin eget",
									  "Nulla et consequat felis", "Vestibulum vel auctor ligula", "Aenean eros nunc, consectetur eu condimentum eu, volutpat quis arcu", "Sed non quam porta, tempus ligula sed, eleifend purus",
									  "Praesent vel metus eu mi tincidunt congue et et sapien", "Sed pretium libero vel mauris pellentesque aliquet", "Morbi id diam ex", "Curabitur eget risus eget neque ullamcorper placerat a vitae nulla",
									  "Donec purus diam, dapibus venenatis molestie vitae, pulvinar sed diam", "Donec vehicula ac ex vitae pretium", "Vestibulum consectetur ultricies nisl, et facilisis turpis convallis iaculis",
									  "Nunc egestas ultricies efficitur", "Duis facilisis felis dignissim mauris dapibus tempus", "Proin a libero viverra, elementum felis a, interdum ipsum",
									  "Proin fringilla, lectus nec ornare dignissim, augue augue consectetur enim, at ullamcorper velit eros quis lacus", "In hac habitasse platea dictumst", "Morbi ullamcorper varius tellus quis elementum",
									  "Aenean odio urna, interdum a purus sit amet, pellentesque fermentum libero", "Mauris non felis nec dui pretium eleifend at id purus", "Morbi lobortis nunc quis velit cursus, eu sodales justo hendrerit",
									  "Nam ex odio, lobortis eu vulputate sed, convallis a purus", "Phasellus ullamcorper eros ac risus consectetur convallis", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas",
									  "Integer ut faucibus arcu", "Donec tempor, mi id tristique egestas, elit turpis faucibus augue, id porttitor eros quam id diam", "Aliquam pharetra enim arcu", "Fusce commodo egestas orci, in sollicitudin lorem",
									  "Praesent sit amet lorem diam", "Phasellus varius felis at lorem porttitor pretium",  "Nam at risus at lacus tincidunt volutpat ut eget elit", "Sed finibus ex in velit aliquet, dapibus tristique nunc sodales",
									  "Ut a dignissim massa", "Sed id porta ligula", "Nunc vel enim diam", "Morbi venenatis nisi eget lectus scelerisque convallis", "Suspendisse et elit ac velit placerat luctus ac quis libero",
									  "Sed nec laoreet quam, vel consectetur metus", "Vestibulum placerat tellus in tortor mattis, sit amet porta ipsum rutrum", "Vivamus nisi mi, pretium a massa vehicula, viverra faucibus sapien",
									  "Sed id faucibus eros, in auctor justo", "Nulla sagittis tempus turpis", "Donec id magna a enim faucibus consequat id pharetra metus", "Cras semper aliquet lectus, vel egestas est tincidunt sed",
									  "Fusce eget risus nec mauris auctor efficitur vitae sed turpis", "Sed at velit sed dolor ornare sodales in tristique ex", "Nulla mollis vulputate arcu, sed maximus mi gravida eget",
									  "Etiam sodales urna eu nisi congue sagittis", "Suspendisse potenti", "Morbi et mattis nisl, vehicula finibus arcu" };
			string[] girlsNames = { "Romanov", "Natasha", "Natasha Romanov", "Viuva Negra", "Agent Carter", "Peggy", "Peggy Carter", "Carter" };
			string[] boysNames = { "Steve", "Rogers", "Recruit", "Capitain", "Steve Rogers", "Buzz", "Lightyear", "Buzz Lightyear" };
			string[] companyNames = { "Tabajara inc.", "ACME", "Pretobrás", "Falling Apple" };

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

			context.TipoItemSomIluminacao.Add(new Model.TipoItemSomIluminacao
			{
				Nome = "DJ",
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.TipoItemSomIluminacao.Add(new Model.TipoItemSomIluminacao
			{
				Nome = "VJ",
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.TipoItemSomIluminacao.Add(new Model.TipoItemSomIluminacao
			{
				Nome = "Técnico",
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.TipoItemSomIluminacao.Add(new Model.TipoItemSomIluminacao
			{
				Nome = "Atração especial",
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.TipoItemSomIluminacao.Add(new Model.TipoItemSomIluminacao
			{
				Nome = "Rider de Banda",
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.SaveChanges();

			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "DJ Full Time", TipoItemSomIluminacaoId = 1, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Não há", TipoItemSomIluminacaoId = 1, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "VJ Full Time", TipoItemSomIluminacaoId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Não há", TipoItemSomIluminacaoId = 2, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Tecnico Full Time", TipoItemSomIluminacaoId = 3, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Tecnico Parcial", TipoItemSomIluminacaoId = 3, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Não há", TipoItemSomIluminacaoId = 3, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Banda (ESPECIFICAR)", TipoItemSomIluminacaoId = 4, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Escola de samba (ESPECIFICAR)", TipoItemSomIluminacaoId = 4, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Grupo de samba (ESPECIFICAR)", TipoItemSomIluminacaoId = 4, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Coral (ESPECIFICAR)", TipoItemSomIluminacaoId = 4, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Não há", TipoItemSomIluminacaoId = 4, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Staff e rider padrão", TipoItemSomIluminacaoId = 5, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemSomIluminacao.Add(new Model.ItemSomIluminacao { Nome = "Não há", TipoItemSomIluminacaoId = 5, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.SaveChanges();

			context.TipoItemFotoVideo.Add(new Model.TipoItemFotoVideo
			{
				Nome = "Equipe de fotografia",
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaSomIluminacao = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.TipoItemFotoVideo.Add(new Model.TipoItemFotoVideo
			{
				Nome = "Serviços especiais",
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaSomIluminacao = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.SaveChanges();

			context.ItemFotoVideo.Add(new Model.ItemFotoVideo { Nome = "Fotos by Produtora 7", TipoItemFotoVideoId = 1, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemFotoVideo.Add(new Model.ItemFotoVideo { Nome = "Fotos produtora externa", TipoItemFotoVideoId = 1, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemFotoVideo.Add(new Model.ItemFotoVideo { Nome = "Não há", TipoItemFotoVideoId = 1, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.ItemFotoVideo.Add(new Model.ItemFotoVideo { Nome = "Cabine de foto", TipoItemFotoVideoId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemFotoVideo.Add(new Model.ItemFotoVideo { Nome = "App para fotos dos convidados no telão", TipoItemFotoVideoId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemFotoVideo.Add(new Model.ItemFotoVideo { Nome = "Não há", TipoItemFotoVideoId = 2, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });

			context.TipoItemBebida.Add(new Model.TipoItemBebida
			{
				Nome = "Bar de caipirinha",
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				CopiaSomIluminacao = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.TipoItemBebida.Add(new Model.TipoItemBebida
			{
				Nome = "Bebida alcoólica",
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				CopiaSomIluminacao = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.TipoItemBebida.Add(new Model.TipoItemBebida
			{
				Nome = "Bebida sem álcool",
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaMontagem = false,
				CopiaOutrosItens = false,
				CopiaSomIluminacao = false,
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = true,
				PadraoDebutante = true,
				PadraoOutro = true
			});
			context.SaveChanges();

			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Nacional (Smirnoff, Sagatiba, Azuma Kirin) com 5 frutas da estação", TipoItemBebidaId = 1, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Importada (Absolut, Seleta, Gekkeikan) com 5 frutas da estação", TipoItemBebidaId = 1, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Não Há", TipoItemBebidaId = 1, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Whiskey (ESPECIFICAR)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Vodka (ESPECIFICAR)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Cachaça (ESPECIFICAR)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Espumante (ESPECIFICAR)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Outra (ESPECIFICAR)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Espumante Brut Casa Valduga (Consignado)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Espumante Brut Casa Valduga (Contratado)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Espumante Brut Casa Valduga (Open Bar)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Vinho Caberten Sauvignon Casa Valduga (Consignado)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Vinho Caberten Sauvignon Casa Valduga (Contratado)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Vinho Caberten Sauvignon Casa Valduga (Open Bar)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Cerveja Heineken (Open Bar)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Cerveja Bavaria Premium (Open Bar)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Cerveja Bohemia (Open Bar)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Cerveja Original (Open Bar)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Cerveja Serra-Malte (Open Bar)", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Não Há", TipoItemBebidaId = 2, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Refrigerante FEMSA [Coca/Coca-Zero/Fanta/Sprite] (Open Bar)", TipoItemBebidaId = 3, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Refrigerante PEPSICO [Pepsi/Pepsi-Twist-Light-Latinha/Sukita/Soda-Limonada/Guaraná] (Open Bar)", TipoItemBebidaId = 3, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Sucos diversos Del-Valle [Laranja/Pêssego/Uva] (Open Bar)", TipoItemBebidaId = 3, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Virgin Cocktail diversos [Meia de seda/Blerg/Éca] (Open Bar)", TipoItemBebidaId = 3, BloqueiaOutrasPropriedades = false, Quantidade = (int)(9 * 10E4) });
			context.ItemBebida.Add(new Model.ItemBebida { Nome = "Não Há", TipoItemBebidaId = 3, BloqueiaOutrasPropriedades = true, Quantidade = (int)(9 * 10E4) });
			context.SaveChanges();

			context.TipoItemMontagem.Add(new Model.TipoItemMontagem
			{
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaOutrosItens = false,
				CopiaSomIluminacao = false,
				Nome = "Montagem teste",
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = false,
				PadraoDebutante = false,
				PadraoOutro = true
			});

			context.TipoItemMontagem.Add(new Model.TipoItemMontagem
			{
				CopiaBebida = false,
				CopiaBoloDoceBemCasado = false,
				CopiaDecoracao = false,
				CopiaFotoVideo = false,
				CopiaOutrosItens = false,
				CopiaSomIluminacao = false,
				Nome = "Montagem teste 2",
				PadraoAniversario = true,
				PadraoBarmitzva = true,
				PadraoBatmitzva = true,
				PadraoCasamento = true,
				PadraoCorporativo = false,
				PadraoDebutante = false,
				PadraoOutro = true
			});

			context.TipoItemMontagem.Add(new Model.TipoItemMontagem
		   {
			   CopiaBebida = false,
			   CopiaBoloDoceBemCasado = false,
			   CopiaDecoracao = false,
			   CopiaFotoVideo = false,
			   CopiaOutrosItens = false,
			   CopiaSomIluminacao = false,
			   Nome = "Montagem teste3",
			   PadraoAniversario = true,
			   PadraoBarmitzva = true,
			   PadraoBatmitzva = true,
			   PadraoCasamento = true,
			   PadraoCorporativo = false,
			   PadraoDebutante = false,
			   PadraoOutro = true
		   });
			context.SaveChanges();

			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = true, Nome = "Não Há", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 1 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 12", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 1 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 11", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 1 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 13", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 1 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = true, Nome = "Não Há", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 15", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 16", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 17", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 18", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 19", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 2", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 3", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 4", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 51", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 6", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 2 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = true, Nome = "Não Há", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 3 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 8", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 3 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 9", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 3 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 10", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 3 });
			context.ItemMontagem.Add(new Model.ItemMontagem { BloqueiaOutrasPropriedades = false, Nome = "Item Montagem 124", Quantidade = (int)(9 * 10E4), TipoItemMontagemId = 3 });
			context.SaveChanges();

			List<Model.ContratoAditivo> contratos = new List<Model.ContratoAditivo>();
			Random rdm = new Random();
			for (int i = 0; i < 50; i++)
			{
				Model.Horario inicio = new Model.Horario { Hora = (17 + rdm.Next(0, 5)), Minuto = 30 };
				Model.Horario termino = new Model.Horario { Hora = inicio.Hora - 15, Minuto = 30 };
				string CPF = string.Empty;
				for (int j = 0; j < 14; j++)
					if (j == 3 || j == 7)
						CPF += ".";
					else if (j == 11)
						CPF += "-";
					else
						CPF += rdm.Next(0, 10).ToString();
				Model.TipoEvento TE = (Model.TipoEvento)rdm.Next(0, 6);
				if (Math.Ceiling((double)i / 3) == (double)i / 3)
					TE = Model.TipoEvento.Casamento;
				string nome = string.Empty;
				if (TE == Model.TipoEvento.Casamento)
					nome = girlsNames[rdm.Next(0, girlsNames.Length)] + " & " + boysNames[rdm.Next(0, boysNames.Length)];
				else if (TE == Model.TipoEvento.Corporativo)
					nome = companyNames[rdm.Next(0, companyNames.Length)];
				else
					nome = boysNames[rdm.Next(0, boysNames.Length)];

				Model.Evento evento = new Model.Evento
				{
					Data = DateTime.Now.AddDays(15 + i + rdm.Next(1, 5)),
					TipoEvento = TE,
					CardapioId = rdm.Next(1, 3),
					EmailBoasVindasEnviado = false,
					CPFResponsavel = CPF,
					EmailContato = string.Empty,
					TelefoneContato = string.Empty,
					Inicio = inicio,
					Termino = termino,
					PossuiAssessoria = false,
					PerfilFesta = sampleText[rdm.Next(0, sampleText.Length)],
					Observacoes = sampleText[rdm.Next(0, sampleText.Length)],
					NomeHomenageados = nome,
					Pax = 200 + rdm.Next(0, 250),
					NomeResponsavel = boysNames[rdm.Next(0, boysNames.Length)],
					LocalCerimonia = Model.LocalCerimonia.NaoPossui,
					LocalId = rdm.Next(1, 7)
				};
				new Business.Evento().CriarEvento(evento);
				for (int j = 0; j < rdm.Next(10); j++)
					contratos.Add(new Model.ContratoAditivo { DataContrato = DateTime.Now.AddDays(-1 * rdm.Next(j, 15)), NumeroContrato = Guid.NewGuid().ToString(), EvtId = evento.Id });
			}

			context.ContratoAditivo.AddRange(contratos);
			context.SaveChanges();

		}
	}
}
