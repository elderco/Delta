using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Web;

namespace VillaBisutti.Delta.Core.Business
{
	public class OS
	{
		public OS(int eventoId)
		{
			Evento = Util.context.Evento
				.Include(e => e.Roteiro)
				.Include(e => e.Cerimonial)
				.Include(e => e.Local)
				.Include(e => e.Produtora)
				.Include(e => e.PosVendedora)
				.Include(e => e.Cardapio)
				.Include(e => e.TipoServico)
				.FirstOrDefault(e => e.Id == eventoId);
		}
		private PDF _pdf;
		private PDF pdf
		{
			get
			{
				if (_pdf == null)
					_pdf = new PDF(Util.GetPDFName(Evento));
				return _pdf;
			}
		}
		private void InicializePDF()
		{
			pdf.PrepareForWriting();
			pdf.SetHeader(Evento.Data, Evento.Local.NomeCasa, Evento.TipoEvento.GetDescription(), Evento.NomeHomenageados, Evento.Pax,
				string.Format("Das {0} às {1}", Evento.Inicio.ToString(), Evento.Termino.ToString()), Evento.LocalCerimonia.GetDescription(),
				Evento.Produtora.Nome, Evento.Produtora.Telefone, Evento.PossuiAssessoria ? "Sim" : "Não", Evento.ContatoAssessoria,
				Evento.NomeResponsavel, Evento.TelefoneContato, Evento.PerfilFesta);
		}
		private Model.Evento Evento;
		private List<DTO.ItemEvento> itensBebida;
		private List<DTO.ItemEvento> ItensBebida
		{
			get
			{
				if (itensBebida == null)
				{
					int currentId = 0;
					itensBebida = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemBebidaSelecionado> itens = Util.context.ItemBebidaSelecionado
						.Include(i => i.ItemBebida)
						.Include(i => i.ItemBebida.TipoItemBebida)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemBebida.Nome)
						.OrderBy(i => i.ItemBebida.TipoItemBebida.Ordem);
					foreach (Model.ItemBebidaSelecionado item in itens)
					{
						if (item.ItemBebida.TipoItemBebidaId != currentId)
						{
							currentId = item.ItemBebida.TipoItemBebidaId;
							itensBebida.Add(new DTO.ItemEvento { Ordem = item.ItemBebida.TipoItemBebida.Ordem, Texto = item.ItemBebida.TipoItemBebida.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensBebida[itensBebida.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemBebida.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = item.FornecimentoBisutti,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioEntrega,
							Observacao = item.Observacoes,
							NomeItem = item.ItemBebida.Nome
						});
					}
				}
				return itensBebida;
			}
		}
		private List<DTO.ItemEvento> itensBolo;
		private List<DTO.ItemEvento> ItensBolo
		{
			get
			{
				if (itensBolo == null)
				{
					int currentId = 0;
					itensBolo = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemBoloDoceBemCasadoSelecionado> itens = Util.context.ItemBoloDoceBemCasadoSelecionado
						.Include(i => i.ItemBoloDoceBemCasado)
						.Include(i => i.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemBoloDoceBemCasado.Nome)
						.OrderBy(i => i.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Ordem);
					foreach (Model.ItemBoloDoceBemCasadoSelecionado item in itens)
					{
						if (item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId != currentId)
						{
							currentId = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId;
							itensBolo.Add(new DTO.ItemEvento { Ordem = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Ordem, Texto = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensBolo[itensBebida.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemBoloDoceBemCasado.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = false,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioEntrega,
							Observacao = item.Observacoes,
							NomeItem = item.ItemBoloDoceBemCasado.Nome
						});
					}
				}
				return itensBebida;
			}
		}
		private List<DTO.ItemEvento> itensDecoracao;
		private List<DTO.ItemEvento> ItensDecoracao
		{
			get
			{
				if (itensDecoracao == null)
				{
					int currentId = 0;
					itensDecoracao = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemDecoracaoSelecionado> itens = Util.context.ItemDecoracaoSelecionado
						.Include(i => i.ItemDecoracao)
						.Include(i => i.ItemDecoracao.TipoItemDecoracao)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemDecoracao.Nome)
						.OrderBy(i => i.ItemDecoracao.TipoItemDecoracao.Ordem);
					foreach (Model.ItemDecoracaoSelecionado item in itens)
					{
						if (item.ItemDecoracao.TipoItemDecoracaoId != currentId)
						{
							currentId = item.ItemDecoracao.TipoItemDecoracaoId;
							itensDecoracao.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracao.TipoItemDecoracao.Ordem, Texto = item.ItemDecoracao.TipoItemDecoracao.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensDecoracao[itensDecoracao.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemDecoracao.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = item.FornecimentoBisutti,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioMontagem,
							Observacao = item.Observacoes,
							NomeItem = item.ItemDecoracao.Nome
						});
					}
				}
				return itensDecoracao;
			}
		}
		private List<DTO.ItemEvento> itensDecoracaoCerimonial;
		private List<DTO.ItemEvento> ItensDecoracaoCerimonial
		{
			get
			{
				if (itensDecoracaoCerimonial == null)
				{
					int currentId = 0;
					itensDecoracaoCerimonial = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemDecoracaoCerimonialSelecionado> itens = Util.context.ItemDecoracaoCerimonialSelecionado
						.Include(i => i.ItemDecoracaoCerimonial)
						.Include(i => i.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemDecoracaoCerimonial.Nome)
						.OrderBy(i => i.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Ordem);
					foreach (Model.ItemDecoracaoCerimonialSelecionado item in itens)
					{
						if (item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId != currentId)
						{
							currentId = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId;
							itensDecoracaoCerimonial.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Ordem, Texto = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensDecoracaoCerimonial[itensDecoracaoCerimonial.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemDecoracaoCerimonial.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = item.FornecimentoBisutti,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioMontagem,
							Observacao = item.Observacoes,
							NomeItem = item.ItemDecoracaoCerimonial.Nome
						});
					}
				}
				return itensDecoracaoCerimonial;
			}
		}
		private List<DTO.ItemEvento> itensFotoVideo;
		private List<DTO.ItemEvento> ItensFotoVideo
		{
			get
			{
				if (itensFotoVideo == null)
				{
					int currentId = 0;
					itensFotoVideo = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemFotoVideoSelecionado> itens = Util.context.ItemFotoVideoSelecionado
						.Include(i => i.ItemFotoVideo)
						.Include(i => i.ItemFotoVideo.TipoItemFotoVideo)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemFotoVideo.Nome)
						.OrderBy(i => i.ItemFotoVideo.TipoItemFotoVideo.Ordem);
					foreach (Model.ItemFotoVideoSelecionado item in itens)
					{
						if (item.ItemFotoVideo.TipoItemFotoVideoId != currentId)
						{
							currentId = item.ItemFotoVideo.TipoItemFotoVideoId;
							itensFotoVideo.Add(new DTO.ItemEvento { Ordem = item.ItemFotoVideo.TipoItemFotoVideo.Ordem, Texto = item.ItemFotoVideo.TipoItemFotoVideo.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensFotoVideo[itensFotoVideo.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemFotoVideo.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = item.FornecimentoBisutti,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioEntrega,
							Observacao = item.Observacoes,
							NomeItem = item.ItemFotoVideo.Nome
						});
					}
				}
				return itensFotoVideo;
			}
		}
		private List<DTO.ItemEvento> itensGastronomia;
		private List<DTO.ItemEvento> ItensGastronomia
		{
			get
			{
				if (itensGastronomia == null)
				{
					int currentId = 0;
					itensGastronomia = new List<DTO.ItemEvento>();
					IEnumerable<Model.PratoSelecionado> itens = Util.context.PratoSelecionado
						.Include(i => i.Prato)
						.Include(i => i.Prato.TipoPrato)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.Prato.Nome)
						.OrderBy(i => i.Prato.TipoPrato.Ordem);
					foreach (Model.PratoSelecionado item in itens)
					{
						if (item.Prato.TipoPratoId != currentId)
						{
							currentId = item.Prato.TipoPratoId;
							int quantidade = Util.context.TipoPratoPadrao.FirstOrDefault(t => t.CardapioId == Evento.CardapioId.Value && t.TipoServicoId == Evento.TipoServicoId.Value && t.TipoPratoId == currentId).QuantidadePratos;
							itensGastronomia.Add(new DTO.ItemEvento { Ordem = item.Prato.TipoPrato.Ordem, Texto = item.Prato.TipoPrato.Nome, Quantidade = quantidade, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensGastronomia[itensGastronomia.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							Fornecido = item.Degustar,
							BloqueiaOutrasPropriedades = item.Rejeitado,
							Responsabilidade = item.Escolhido,
							ContatoFornecedor = string.Empty,
							QuantidadeItem = 0,
							HorarioEntrega = 0,
							Observacao = item.Observacoes,
							NomeItem = item.Prato.Nome
						});
					}
				}
				return itensGastronomia;
			}
		}
		private List<DTO.ItemEvento> itensMontagem;
		private List<DTO.ItemEvento> ItensMontagem
		{
			get
			{
				if (itensMontagem == null)
				{
					int currentId = 0;
					itensMontagem = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemMontagemSelecionado> itens = Util.context.ItemMontagemSelecionado
						.Include(i => i.ItemMontagem)
						.Include(i => i.ItemMontagem.TipoItemMontagem)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemMontagem.Nome)
						.OrderBy(i => i.ItemMontagem.TipoItemMontagem.Ordem);
					foreach (Model.ItemMontagemSelecionado item in itens)
					{
						if (item.ItemMontagem.TipoItemMontagemId != currentId)
						{
							currentId = item.ItemMontagem.TipoItemMontagemId;
							itensMontagem.Add(new DTO.ItemEvento { Ordem = item.ItemMontagem.TipoItemMontagem.Ordem, Texto = item.ItemMontagem.TipoItemMontagem.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensMontagem[itensMontagem.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemMontagem.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = item.FornecimentoBisutti,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioEntrega,
							Observacao = item.Observacoes,
							NomeItem = item.ItemMontagem.Nome
						});
					}
				}
				return itensMontagem;
			}
		}
		private List<DTO.ItemEvento> itensOutrosItens;
		private List<DTO.ItemEvento> ItensOutrosItens
		{
			get
			{
				if (itensOutrosItens == null)
				{
					int currentId = 0;
					itensOutrosItens = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemOutrosItensSelecionado> itens = Util.context.ItemOutrosItensSelecionado
						.Include(i => i.ItemOutrosItens)
						.Include(i => i.ItemOutrosItens.TipoItemOutrosItens)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemOutrosItens.Nome)
						.OrderBy(i => i.ItemOutrosItens.TipoItemOutrosItens.Ordem);
					foreach (Model.ItemOutrosItensSelecionado item in itens)
					{
						if (item.ItemOutrosItens.TipoItemOutrosItensId != currentId)
						{
							currentId = item.ItemOutrosItens.TipoItemOutrosItensId;
							itensOutrosItens.Add(new DTO.ItemEvento { Ordem = item.ItemOutrosItens.TipoItemOutrosItens.Ordem, Texto = item.ItemOutrosItens.TipoItemOutrosItens.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensOutrosItens[itensOutrosItens.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemOutrosItens.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = item.FornecimentoBisutti,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioEntrega,
							Observacao = item.Observacoes,
							NomeItem = item.ItemOutrosItens.Nome
						});
					}
				}
				return itensOutrosItens;
			}
		}
		private List<DTO.ItemEvento> itensSomIluminacao;
		private List<DTO.ItemEvento> ItensSomIluminacao
		{
			get
			{
				if (itensSomIluminacao == null)
				{
					int currentId = 0;
					itensSomIluminacao = new List<DTO.ItemEvento>();
					IEnumerable<Model.ItemSomIluminacaoSelecionado> itens = Util.context.ItemSomIluminacaoSelecionado
						.Include(i => i.ItemSomIluminacao)
						.Include(i => i.ItemSomIluminacao.TipoItemSomIluminacao)
						.Where(i => i.EventoId == Evento.Id)
						.OrderBy(i => i.ItemSomIluminacao.Nome)
						.OrderBy(i => i.ItemSomIluminacao.TipoItemSomIluminacao.Ordem);
					foreach (Model.ItemSomIluminacaoSelecionado item in itens)
					{
						if (item.ItemSomIluminacao.TipoItemSomIluminacaoId != currentId)
						{
							currentId = item.ItemSomIluminacao.TipoItemSomIluminacaoId;
							itensSomIluminacao.Add(new DTO.ItemEvento { Ordem = item.ItemSomIluminacao.TipoItemSomIluminacao.Ordem, Texto = item.ItemSomIluminacao.TipoItemSomIluminacao.Nome, SubItens = new List<DTO.SubItemEvento>() });
						}
						itensSomIluminacao[itensSomIluminacao.Count - 1].SubItens.Add(new DTO.SubItemEvento
						{
							BloqueiaOutrasPropriedades = item.ItemSomIluminacao.BloqueiaOutrasPropriedades,
							ContatoFornecedor = item.ContatoFornecimento,
							Fornecido = item.FornecimentoBisutti,
							Responsabilidade = item.ContratacaoBisutti,
							QuantidadeItem = item.Quantidade,
							HorarioEntrega = item.HorarioMontagem,
							Observacao = item.Observacoes,
							NomeItem = item.ItemSomIluminacao.Nome
						});
					}
				}
				return itensSomIluminacao;
			}
		}
		private List<DTO.ItemRoteiroEvento> itensRoteiro;
		private List<DTO.ItemRoteiroEvento> ItensRoteiro
		{
			get
			{
				if (itensRoteiro == null)
				{
					itensRoteiro = new List<DTO.ItemRoteiroEvento>();
					foreach (Model.ItemRoteiro item in Util.context.ItemRoteiro.Where(ir => ir.EventoId == Evento.Id).OrderBy(ir => ir.HorarioInicio))
						itensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = item.Titulo, Horario = item.Inicio, Importante = item.Importante, Observacoes = item.Observacao });
				}
				return itensRoteiro;
			}
		}
		private List<DTO.ItemRoteiroEvento> itensRoteiroCerimonial;
		private List<DTO.ItemRoteiroEvento> ItensRoteiroCerimonial
		{
			get
			{
				if (itensRoteiroCerimonial == null)
				{
					itensRoteiroCerimonial = new List<DTO.ItemRoteiroEvento>();
					foreach (Model.ItemCerimonial item in Util.context.ItemCerimonial.Where(ir => ir.EventoId == Evento.Id).OrderBy(ir => ir.HorarioInicio))
						itensRoteiroCerimonial.Add(new DTO.ItemRoteiroEvento { Acontecimento = item.Titulo, Horario = item.Inicio, Importante = item.Importante, Observacoes = item.Observacao });
				}
				return itensRoteiroCerimonial;
			}
		}
		private List<Model.Foto> fotos;
		private List<Model.Foto> Fotos
		{
			get
			{
				if (fotos == null)
					fotos = Util.context.Foto.Where(f => f.EventoId == Evento.Id).ToList();
				return fotos;
			}
		}
		private void AdicionarPaginaPrincipal()
		{
			pdf.AddHeader();
			pdf.AddLeadText(Evento.NomeHomenageados);
			pdf.AddLine("Contato: " + Evento.NomeResponsavel + " - " + Evento.EmailContato + " - " + Evento.TelefoneContato);
			pdf.AddLine("CPF: " + Evento.CPFResponsavel);
			pdf.AddLine("Observações: " + Evento.Observacoes);
			pdf.AddLine("Perfil da festa: " + Evento.PerfilFesta);
			pdf.AddBreakRule();

			pdf.AddLeadText("Pós-venda: " + Evento.PosVendedora.Nome + " - " + Evento.PosVendedora.Telefone);
			pdf.AddLeadText("Produção: " + Evento.Produtora.Nome + " - " + Evento.Produtora.Telefone + " - " + Evento.Produtora.Telefone);
			pdf.AddLeadText("Possui assessoria? " + (Evento.PossuiAssessoria ? "Sim" : "Não"));
			if (Evento.PossuiAssessoria)
				pdf.AddLine("Contato: " + Evento.ContatoAssessoria);
			pdf.AddBreakRule();

			pdf.AddLeadText("Tipo de evento: " + Evento.TipoEvento.GetDescription());
			pdf.AddLeadText("Local: " + Evento.Local.NomeCasa);
			pdf.AddLine(Evento.Local.EnderecoCasa);
			pdf.AddLeadText("Data: " + Evento.Data.ToString("dddd, dd/MM/yyyy") + ", das " + Evento.Inicio.ToString() + " às " + Evento.Termino.ToString());
			pdf.AddLeadText("Pax: " + Evento.Pax + " (+10%: " + (Evento.Pax * 1.1) + ") pessoas.");
			pdf.AddLeadText("Cerimonial: " + Evento.LocalCerimonia.GetDescription());
			if (!string.IsNullOrEmpty(Evento.EnderecoCerimonia))
				pdf.AddLine(Evento.EnderecoCerimonia);
			if (!string.IsNullOrEmpty(Evento.ObservacoesCerimonia))
				pdf.AddLine(Evento.ObservacoesCerimonia);
			pdf.AddBreakRule();

			pdf.AddLeadText("Cardápio: " + Evento.Cardapio.Nome);
			pdf.AddLeadText("Tipo de serviço: " + Evento.TipoServico.Nome);
			pdf.AddBreakRule();
			pdf.BreakPage();
		}
		private void AdicionarPaginaLayout()
		{
			pdf.BreakPage();
			pdf.AddHeader();
			pdf.AddLeadText("Layout do salão");
			pdf.AddBreakRule();

			Model.Foto layout = Fotos.FirstOrDefault(f => f.Qual == "EV");
			pdf.AddImage(HttpContext.Current.Server.MapPath(layout.URL), layout.Legenda, true);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaBebidas()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Bebidas");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensBebida)
			{
				IEnumerable<DTO.SubItemEvento> FornecidoBisutti = grupo.SubItens.Where(s => s.Responsabilidade && s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoTerceiro = grupo.SubItens.Where(s => s.Responsabilidade && !s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoContratante = grupo.SubItens.Where(s => !s.Responsabilidade);
				pdf.AddLeadText(grupo.Texto);
				if (FornecidoBisutti.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.SubItemEvento item in FornecidoBisutti)
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				if (FornecidoBisutti.Count() > 0)
					pdf.BreakLine();
				if (FornecidoTerceiro.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.SubItemEvento item in FornecidoTerceiro)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoTerceiro.Count() > 0)
					pdf.BreakLine();
				if (FornecidoContratante.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.SubItemEvento item in FornecidoContratante)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoContratante.Count() > 0)
					pdf.AddBreakRule();
			}
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == "BB"))
				pdf.AddImage(HttpContext.Current.Server.MapPath(foto.URL), foto.Legenda);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaDecoracao()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Decoração da recepção");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensDecoracao)
			{
				IEnumerable<DTO.SubItemEvento> FornecidoBisutti = grupo.SubItens.Where(s => s.Responsabilidade && s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoTerceiro = grupo.SubItens.Where(s => s.Responsabilidade && !s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoContratante = grupo.SubItens.Where(s => !s.Responsabilidade);
				pdf.AddLeadText(grupo.Texto);
				if (FornecidoBisutti.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.SubItemEvento item in FornecidoBisutti)
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				if (FornecidoBisutti.Count() > 0)
					pdf.BreakLine();
				if (FornecidoTerceiro.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.SubItemEvento item in FornecidoTerceiro)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoTerceiro.Count() > 0)
					pdf.BreakLine();
				if (FornecidoContratante.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.SubItemEvento item in FornecidoContratante)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoContratante.Count() > 0)
					pdf.AddBreakRule();
			}
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == "DR"))
				pdf.AddImage(HttpContext.Current.Server.MapPath(foto.URL), foto.Legenda);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaDecoracaoCerimonial()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Decoração da cerimônia");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensDecoracaoCerimonial)
			{
				IEnumerable<DTO.SubItemEvento> FornecidoBisutti = grupo.SubItens.Where(s => s.Responsabilidade && s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoTerceiro = grupo.SubItens.Where(s => s.Responsabilidade && !s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoContratante = grupo.SubItens.Where(s => !s.Responsabilidade);
				pdf.AddLeadText(grupo.Texto);
				if (FornecidoBisutti.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.SubItemEvento item in FornecidoBisutti)
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				if (FornecidoBisutti.Count() > 0)
					pdf.BreakLine();
				if (FornecidoTerceiro.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.SubItemEvento item in FornecidoTerceiro)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoTerceiro.Count() > 0)
					pdf.BreakLine();
				if (FornecidoContratante.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.SubItemEvento item in FornecidoContratante)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoContratante.Count() > 0)
					pdf.AddBreakRule();
			}
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == "DC"))
				pdf.AddImage(HttpContext.Current.Server.MapPath(foto.URL), foto.Legenda);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaFotoVideo()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Itens de Foto & Vídeo");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensFotoVideo)
			{
				IEnumerable<DTO.SubItemEvento> FornecidoBisutti = grupo.SubItens.Where(s => s.Responsabilidade && s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoTerceiro = grupo.SubItens.Where(s => s.Responsabilidade && !s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoContratante = grupo.SubItens.Where(s => !s.Responsabilidade);
				pdf.AddLeadText(grupo.Texto);
				if (FornecidoBisutti.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.SubItemEvento item in FornecidoBisutti)
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				if (FornecidoBisutti.Count() > 0)
					pdf.BreakLine();
				if (FornecidoTerceiro.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.SubItemEvento item in FornecidoTerceiro)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoTerceiro.Count() > 0)
					pdf.BreakLine();
				if (FornecidoContratante.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.SubItemEvento item in FornecidoContratante)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoContratante.Count() > 0)
					pdf.AddBreakRule();
			}
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == "FV"))
				pdf.AddImage(HttpContext.Current.Server.MapPath(foto.URL), foto.Legenda);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaGastronomia(bool incluiDegustar)
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Gastronomia");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensGastronomia)
			{
				pdf.AddLeadText(grupo.Texto + (incluiDegustar ? " (Escolher " + grupo.Quantidade + " itens)" : ""));
				foreach(DTO.SubItemEvento item in grupo.SubItens.OrderBy(i => i.BloqueiaOutrasPropriedades).OrderBy(i => i.Responsabilidade).OrderBy(i => i.Fornecido))
				{
					//BloqueiaOutrasPropriedades = item.Rejeitado,
					//Responsabilidade = item.Escolhido,
					//Fornecido = item.Degustar,
					if(item.BloqueiaOutrasPropriedades)
						continue;
					if((item.Fornecido && incluiDegustar) || (item.Responsabilidade))
						pdf.AddLine(item.NomeItem, true);
				}
				pdf.BreakLine();
			}
			pdf.BreakPage();
		}
		private void AdicionarPaginaMontagem()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Montagem do Salão");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensDecoracaoCerimonial)
			{
				IEnumerable<DTO.SubItemEvento> FornecidoBisutti = grupo.SubItens.Where(s => s.Responsabilidade && s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoTerceiro = grupo.SubItens.Where(s => s.Responsabilidade && !s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoContratante = grupo.SubItens.Where(s => !s.Responsabilidade);
				pdf.AddLeadText(grupo.Texto);
				if (FornecidoBisutti.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.SubItemEvento item in FornecidoBisutti)
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				if (FornecidoBisutti.Count() > 0)
					pdf.BreakLine();
				if (FornecidoTerceiro.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.SubItemEvento item in FornecidoTerceiro)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoTerceiro.Count() > 0)
					pdf.BreakLine();
				if (FornecidoContratante.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.SubItemEvento item in FornecidoContratante)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoContratante.Count() > 0)
					pdf.AddBreakRule();
			}
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == "MS"))
				pdf.AddImage(HttpContext.Current.Server.MapPath(foto.URL), foto.Legenda);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaOutrosItens()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Outros itens");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensDecoracaoCerimonial)
			{
				IEnumerable<DTO.SubItemEvento> FornecidoBisutti = grupo.SubItens.Where(s => s.Responsabilidade && s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoTerceiro = grupo.SubItens.Where(s => s.Responsabilidade && !s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoContratante = grupo.SubItens.Where(s => !s.Responsabilidade);
				pdf.AddLeadText(grupo.Texto);
				if (FornecidoBisutti.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.SubItemEvento item in FornecidoBisutti)
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				if (FornecidoBisutti.Count() > 0)
					pdf.BreakLine();
				if (FornecidoTerceiro.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.SubItemEvento item in FornecidoTerceiro)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoTerceiro.Count() > 0)
					pdf.BreakLine();
				if (FornecidoContratante.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.SubItemEvento item in FornecidoContratante)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoContratante.Count() > 0)
					pdf.AddBreakRule();
			}
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == "OI"))
				pdf.AddImage(HttpContext.Current.Server.MapPath(foto.URL), foto.Legenda);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaSomIluminacao()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Itens de Som e Iluminação");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensSomIluminacao)
			{
				IEnumerable<DTO.SubItemEvento> FornecidoBisutti = grupo.SubItens.Where(s => s.Responsabilidade && s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoTerceiro = grupo.SubItens.Where(s => s.Responsabilidade && !s.Fornecido);
				IEnumerable<DTO.SubItemEvento> FornecidoContratante = grupo.SubItens.Where(s => !s.Responsabilidade);
				pdf.AddLeadText(grupo.Texto);
				if (FornecidoBisutti.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.SubItemEvento item in FornecidoBisutti)
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				if (FornecidoBisutti.Count() > 0)
					pdf.BreakLine();
				if (FornecidoTerceiro.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.SubItemEvento item in FornecidoTerceiro)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoTerceiro.Count() > 0)
					pdf.BreakLine();
				if (FornecidoContratante.Count() > 0)
					pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.SubItemEvento item in FornecidoContratante)
				{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
					ItensRoteiro.Add(new DTO.ItemRoteiroEvento { Acontecimento = "Montagem de " + item.NomeItem, Observacoes = item.ContatoFornecedor, Importante = true, Horario = Model.Horario.Parse(item.HorarioEntrega) });
				}
				if (FornecidoContratante.Count() > 0)
					pdf.AddBreakRule();
			}
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == "SI"))
				pdf.AddImage(HttpContext.Current.Server.MapPath(foto.URL), foto.Legenda);
			pdf.BreakPage();
			pdf.BreakPage();
		}
		private void AdicionarPaginaRoteiro()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Roteiro");
			pdf.AddBreakRule();
			foreach (DTO.ItemRoteiroEvento item in ItensRoteiro)
			{
					pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.Horario, item.Acontecimento, item.Observacoes), item.Importante);
			}
			pdf.BreakPage();
		}
		private void AdicionarPaginaRoteiroCerimonial()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Roteiro do cerimonial");
			pdf.AddBreakRule();
			foreach (DTO.ItemRoteiroEvento item in ItensRoteiroCerimonial)
			{
				pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.Horario, item.Acontecimento, item.Observacoes), item.Importante);
			}
			pdf.BreakPage();
		}
		public void GerarOS()
		{
			InicializePDF();

			AdicionarPaginaPrincipal();
			AdicionarPaginaDecoracao();
			AdicionarPaginaDecoracaoCerimonial();
			AdicionarPaginaFotoVideo();
			AdicionarPaginaGastronomia(false);
			AdicionarPaginaMontagem();
			AdicionarPaginaOutrosItens();
			AdicionarPaginaSomIluminacao();
			AdicionarPaginaLayout();
			AdicionarPaginaRoteiro();
			AdicionarPaginaRoteiroCerimonial();
		}
		public void GerarDegustacao()
		{
			InicializePDF();
			AdicionarPaginaGastronomia(true);
		}
		public void SetOSFinalizada()
		{
			Evento.OSFinalizada = true;
			Model.Evento thisEvento = Util.context.Evento.FirstOrDefault(e => e.Id == Evento.Id);
			Util.context.Entry(thisEvento).CurrentValues.SetValues(Evento);
			Util.context.Entry(thisEvento).State = EntityState.Modified;
			Util.context.SaveChanges();
		}
		public void Kill()
		{
			pdf.FinishWriting();
			_pdf = null;
			Evento = null;
			itensBebida = null;
			itensBolo = null;
			itensDecoracao = null;
			itensDecoracaoCerimonial = null;
			itensFotoVideo = null;
			itensGastronomia = null;
			itensMontagem = null;
			itensOutrosItens = null;
			itensRoteiro = null;
			itensSomIluminacao = null;
		}
	}
}
