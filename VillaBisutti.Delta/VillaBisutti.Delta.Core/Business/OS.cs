﻿using System;
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
			PopularItensBebida();
			PopularItensBolo();
			PopularItensDecoracao();
			PopularItensDecoracaoCerimonial();
			PopularItensFotoVideo();
			PopularItensMontagem();
			PopularItensOutrosItens();
			PopularItensSomIluminacao();
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
				Evento.Produtora == null ? "Produtora indefinida" : Evento.Produtora.Nome,
				Evento.Produtora == null ? "Telefone da produtora indisponível" : Evento.Produtora.Telefone,
				Evento.PossuiAssessoria ? "Sim" : "Não", Evento.ContatoAssessoria,
				Evento.NomeResponsavel, Evento.TelefoneContato, Evento.PerfilFesta);
		}
		private Model.Evento Evento;

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
						.Where(i => i.EventoId == Evento.Id && (i.Degustar || i.Escolhido))
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

		private List<DTO.ItemEvento> ItensBebidaBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensBebidaTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensBebidaContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensBoloTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensBoloContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensDecoracaoBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensDecoracaoTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensDecoracaoContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensDecoracaoCerimonialBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensDecoracaoCerimonialTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensDecoracaoCerimonialContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensFotoVideoBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensFotoVideoTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensFotoVideoContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensMontagemBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensMontagemTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensMontagemContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensOutrosItensBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensOutrosItensTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensOutrosItensContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensSomIluminacaoBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensSomIluminacaoTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> ItensSomIluminacaoContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensBebidaBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensBebidaTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensBebidaContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensBoloTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensBoloContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensDecoracaoBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensDecoracaoTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensDecoracaoContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensDecoracaoCerimonialBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensDecoracaoCerimonialTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensDecoracaoCerimonialContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensFotoVideoBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensFotoVideoTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensFotoVideoContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensMontagemBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensMontagemTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensMontagemContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensOutrosItensBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensOutrosItensTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensOutrosItensContratante = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensSomIluminacaoBisutti = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensSomIluminacaoTerceiro = new List<DTO.ItemEvento>();
		private List<DTO.ItemEvento> CopiaItensSomIluminacaoContratante = new List<DTO.ItemEvento>();

		private void PopularItensBebida()
		{
			IEnumerable<Model.ItemBebidaSelecionado> itens = Util.context.ItemBebidaSelecionado
				.Include(i => i.ItemBebida)
				.Include(i => i.ItemBebida.TipoItemBebida)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemBebida.Nome)
				.OrderBy(i => i.ItemBebida.TipoItemBebida.Ordem);
			int currentId = 0;
			foreach (Model.ItemBebidaSelecionado item in itens.Where(i => i.ContratacaoBisutti && i.FornecimentoBisutti))
			{
				if (item.ItemBebida.TipoItemBebidaId != currentId)
				{
					currentId = item.ItemBebida.TipoItemBebidaId;
					ItensBebidaBisutti.Add(new DTO.ItemEvento { Ordem = item.ItemBebida.TipoItemBebida.Ordem, Texto = item.ItemBebida.TipoItemBebida.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensBebidaBisutti[ItensBebidaBisutti.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemBebidaSelecionado item in itens.Where(i => i.ContratacaoBisutti && !i.FornecimentoBisutti))
			{
				if (item.ItemBebida.TipoItemBebidaId != currentId)
				{
					currentId = item.ItemBebida.TipoItemBebidaId;
					ItensBebidaTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemBebida.TipoItemBebida.Ordem, Texto = item.ItemBebida.TipoItemBebida.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensBebidaTerceiro[ItensBebidaTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemBebidaSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemBebida.TipoItemBebidaId != currentId)
				{
					currentId = item.ItemBebida.TipoItemBebidaId;
					ItensBebidaContratante.Add(new DTO.ItemEvento { Ordem = item.ItemBebida.TipoItemBebida.Ordem, Texto = item.ItemBebida.TipoItemBebida.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensBebidaContratante[ItensBebidaContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
		private void PopularItensBolo()
		{
			IEnumerable<Model.ItemBoloDoceBemCasadoSelecionado> itens = Util.context.ItemBoloDoceBemCasadoSelecionado
				.Include(i => i.ItemBoloDoceBemCasado)
				.Include(i => i.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemBoloDoceBemCasado.Nome)
				.OrderBy(i => i.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Ordem);
			int currentId = 0;
			foreach (Model.ItemBoloDoceBemCasadoSelecionado item in itens.Where(i => i.ContratacaoBisutti))
			{
				if (item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId != currentId)
				{
					currentId = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId;
					ItensBoloTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Ordem, Texto = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensBoloTerceiro[ItensBoloTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemBoloDoceBemCasadoSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId != currentId)
				{
					currentId = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId;
					ItensBoloContratante.Add(new DTO.ItemEvento { Ordem = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Ordem, Texto = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensBoloContratante[ItensBoloContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
		private void PopularItensDecoracao()
		{
			IEnumerable<Model.ItemDecoracaoSelecionado> itens = Util.context.ItemDecoracaoSelecionado
				.Include(i => i.ItemDecoracao)
				.Include(i => i.ItemDecoracao.TipoItemDecoracao)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemDecoracao.Nome)
				.OrderBy(i => i.ItemDecoracao.TipoItemDecoracao.Ordem);
			int currentId = 0;
			foreach (Model.ItemDecoracaoSelecionado item in itens.Where(i => i.ContratacaoBisutti && i.FornecimentoBisutti))
			{
				if (item.ItemDecoracao.TipoItemDecoracaoId != currentId)
				{
					currentId = item.ItemDecoracao.TipoItemDecoracaoId;
					ItensDecoracaoBisutti.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracao.TipoItemDecoracao.Ordem, Texto = item.ItemDecoracao.TipoItemDecoracao.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensDecoracaoBisutti[ItensDecoracaoBisutti.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemDecoracaoSelecionado item in itens.Where(i => i.ContratacaoBisutti && !i.FornecimentoBisutti))
			{
				if (item.ItemDecoracao.TipoItemDecoracaoId != currentId)
				{
					currentId = item.ItemDecoracao.TipoItemDecoracaoId;
					ItensDecoracaoTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracao.TipoItemDecoracao.Ordem, Texto = item.ItemDecoracao.TipoItemDecoracao.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensDecoracaoTerceiro[ItensDecoracaoTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemDecoracaoSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemDecoracao.TipoItemDecoracaoId != currentId)
				{
					currentId = item.ItemDecoracao.TipoItemDecoracaoId;
					ItensDecoracaoContratante.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracao.TipoItemDecoracao.Ordem, Texto = item.ItemDecoracao.TipoItemDecoracao.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensDecoracaoContratante[ItensDecoracaoContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
		private void PopularItensDecoracaoCerimonial()
		{
			IEnumerable<Model.ItemDecoracaoCerimonialSelecionado> itens = Util.context.ItemDecoracaoCerimonialSelecionado
				.Include(i => i.ItemDecoracaoCerimonial)
				.Include(i => i.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemDecoracaoCerimonial.Nome)
				.OrderBy(i => i.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Ordem);
			int currentId = 0;
			foreach (Model.ItemDecoracaoCerimonialSelecionado item in itens.Where(i => i.ContratacaoBisutti && i.FornecimentoBisutti))
			{
				if (item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId != currentId)
				{
					currentId = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId;
					ItensDecoracaoCerimonialBisutti.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Ordem, Texto = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensDecoracaoCerimonialBisutti[ItensDecoracaoCerimonialBisutti.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemDecoracaoCerimonialSelecionado item in itens.Where(i => i.ContratacaoBisutti && !i.FornecimentoBisutti))
			{
				if (item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId != currentId)
				{
					currentId = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId;
					ItensDecoracaoCerimonialTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Ordem, Texto = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensDecoracaoCerimonialTerceiro[ItensDecoracaoCerimonialTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemDecoracaoCerimonialSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId != currentId)
				{
					currentId = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId;
					ItensDecoracaoCerimonialContratante.Add(new DTO.ItemEvento { Ordem = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Ordem, Texto = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensDecoracaoCerimonialContratante[ItensDecoracaoCerimonialContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
		private void PopularItensFotoVideo()
		{
			IEnumerable<Model.ItemFotoVideoSelecionado> itens = Util.context.ItemFotoVideoSelecionado
				.Include(i => i.ItemFotoVideo)
				.Include(i => i.ItemFotoVideo.TipoItemFotoVideo)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemFotoVideo.Nome)
				.OrderBy(i => i.ItemFotoVideo.TipoItemFotoVideo.Ordem);
			int currentId = 0;
			foreach (Model.ItemFotoVideoSelecionado item in itens.Where(i => i.ContratacaoBisutti && i.FornecimentoBisutti))
			{
				if (item.ItemFotoVideo.TipoItemFotoVideoId != currentId)
				{
					currentId = item.ItemFotoVideo.TipoItemFotoVideoId;
					ItensFotoVideoBisutti.Add(new DTO.ItemEvento { Ordem = item.ItemFotoVideo.TipoItemFotoVideo.Ordem, Texto = item.ItemFotoVideo.TipoItemFotoVideo.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensFotoVideoBisutti[ItensFotoVideoBisutti.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemFotoVideoSelecionado item in itens.Where(i => i.ContratacaoBisutti && !i.FornecimentoBisutti))
			{
				if (item.ItemFotoVideo.TipoItemFotoVideoId != currentId)
				{
					currentId = item.ItemFotoVideo.TipoItemFotoVideoId;
					ItensFotoVideoTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemFotoVideo.TipoItemFotoVideo.Ordem, Texto = item.ItemFotoVideo.TipoItemFotoVideo.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensFotoVideoTerceiro[ItensFotoVideoTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemFotoVideoSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemFotoVideo.TipoItemFotoVideoId != currentId)
				{
					currentId = item.ItemFotoVideo.TipoItemFotoVideoId;
					ItensFotoVideoContratante.Add(new DTO.ItemEvento { Ordem = item.ItemFotoVideo.TipoItemFotoVideo.Ordem, Texto = item.ItemFotoVideo.TipoItemFotoVideo.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensFotoVideoContratante[ItensFotoVideoContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
		private void PopularItensMontagem()
		{
			IEnumerable<Model.ItemMontagemSelecionado> itens = Util.context.ItemMontagemSelecionado
				.Include(i => i.ItemMontagem)
				.Include(i => i.ItemMontagem.TipoItemMontagem)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemMontagem.Nome)
				.OrderBy(i => i.ItemMontagem.TipoItemMontagem.Ordem);
			int currentId = 0;
			foreach (Model.ItemMontagemSelecionado item in itens.Where(i => i.ContratacaoBisutti && i.FornecimentoBisutti))
			{
				if (item.ItemMontagem.TipoItemMontagemId != currentId)
				{
					currentId = item.ItemMontagem.TipoItemMontagemId;
					ItensMontagemBisutti.Add(new DTO.ItemEvento { Ordem = item.ItemMontagem.TipoItemMontagem.Ordem, Texto = item.ItemMontagem.TipoItemMontagem.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensMontagemBisutti[ItensMontagemBisutti.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemMontagemSelecionado item in itens.Where(i => i.ContratacaoBisutti && !i.FornecimentoBisutti))
			{
				if (item.ItemMontagem.TipoItemMontagemId != currentId)
				{
					currentId = item.ItemMontagem.TipoItemMontagemId;
					ItensMontagemTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemMontagem.TipoItemMontagem.Ordem, Texto = item.ItemMontagem.TipoItemMontagem.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensMontagemTerceiro[ItensMontagemTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemMontagemSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemMontagem.TipoItemMontagemId != currentId)
				{
					currentId = item.ItemMontagem.TipoItemMontagemId;
					ItensMontagemContratante.Add(new DTO.ItemEvento { Ordem = item.ItemMontagem.TipoItemMontagem.Ordem, Texto = item.ItemMontagem.TipoItemMontagem.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensMontagemContratante[ItensMontagemContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
		private void PopularItensOutrosItens()
		{
			IEnumerable<Model.ItemOutrosItensSelecionado> itens = Util.context.ItemOutrosItensSelecionado
				.Include(i => i.ItemOutrosItens)
				.Include(i => i.ItemOutrosItens.TipoItemOutrosItens)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemOutrosItens.Nome)
				.OrderBy(i => i.ItemOutrosItens.TipoItemOutrosItens.Ordem);
			int currentId = 0;
			foreach (Model.ItemOutrosItensSelecionado item in itens.Where(i => i.ContratacaoBisutti && i.FornecimentoBisutti))
			{
				if (item.ItemOutrosItens.TipoItemOutrosItensId != currentId)
				{
					currentId = item.ItemOutrosItens.TipoItemOutrosItensId;
					ItensOutrosItensBisutti.Add(new DTO.ItemEvento { Ordem = item.ItemOutrosItens.TipoItemOutrosItens.Ordem, Texto = item.ItemOutrosItens.TipoItemOutrosItens.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensOutrosItensBisutti[ItensOutrosItensBisutti.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemOutrosItensSelecionado item in itens.Where(i => i.ContratacaoBisutti && !i.FornecimentoBisutti))
			{
				if (item.ItemOutrosItens.TipoItemOutrosItensId != currentId)
				{
					currentId = item.ItemOutrosItens.TipoItemOutrosItensId;
					ItensOutrosItensTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemOutrosItens.TipoItemOutrosItens.Ordem, Texto = item.ItemOutrosItens.TipoItemOutrosItens.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensOutrosItensTerceiro[ItensOutrosItensTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemOutrosItensSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemOutrosItens.TipoItemOutrosItensId != currentId)
				{
					currentId = item.ItemOutrosItens.TipoItemOutrosItensId;
					ItensOutrosItensContratante.Add(new DTO.ItemEvento { Ordem = item.ItemOutrosItens.TipoItemOutrosItens.Ordem, Texto = item.ItemOutrosItens.TipoItemOutrosItens.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensOutrosItensContratante[ItensOutrosItensContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
		private void PopularItensSomIluminacao()
		{
			IEnumerable<Model.ItemSomIluminacaoSelecionado> itens = Util.context.ItemSomIluminacaoSelecionado
				.Include(i => i.ItemSomIluminacao)
				.Include(i => i.ItemSomIluminacao.TipoItemSomIluminacao)
				.Where(i => i.EventoId == Evento.Id)
				.OrderBy(i => i.ItemSomIluminacao.Nome)
				.OrderBy(i => i.ItemSomIluminacao.TipoItemSomIluminacao.Ordem);
			int currentId = 0;
			foreach (Model.ItemSomIluminacaoSelecionado item in itens.Where(i => i.ContratacaoBisutti && i.FornecimentoBisutti))
			{
				if (item.ItemSomIluminacao.TipoItemSomIluminacaoId != currentId)
				{
					currentId = item.ItemSomIluminacao.TipoItemSomIluminacaoId;
					ItensSomIluminacaoBisutti.Add(new DTO.ItemEvento { Ordem = item.ItemSomIluminacao.TipoItemSomIluminacao.Ordem, Texto = item.ItemSomIluminacao.TipoItemSomIluminacao.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensSomIluminacaoBisutti[ItensSomIluminacaoBisutti.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemSomIluminacaoSelecionado item in itens.Where(i => i.ContratacaoBisutti && !i.FornecimentoBisutti))
			{
				if (item.ItemSomIluminacao.TipoItemSomIluminacaoId != currentId)
				{
					currentId = item.ItemSomIluminacao.TipoItemSomIluminacaoId;
					ItensSomIluminacaoTerceiro.Add(new DTO.ItemEvento { Ordem = item.ItemSomIluminacao.TipoItemSomIluminacao.Ordem, Texto = item.ItemSomIluminacao.TipoItemSomIluminacao.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensSomIluminacaoTerceiro[ItensSomIluminacaoTerceiro.Count - 1].SubItens.Add(new DTO.SubItemEvento
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
			currentId = 0;
			foreach (Model.ItemSomIluminacaoSelecionado item in itens.Where(i => !i.ContratacaoBisutti))
			{
				if (item.ItemSomIluminacao.TipoItemSomIluminacaoId != currentId)
				{
					currentId = item.ItemSomIluminacao.TipoItemSomIluminacaoId;
					ItensSomIluminacaoContratante.Add(new DTO.ItemEvento { Ordem = item.ItemSomIluminacao.TipoItemSomIluminacao.Ordem, Texto = item.ItemSomIluminacao.TipoItemSomIluminacao.Nome, SubItens = new List<DTO.SubItemEvento>() });
				}
				ItensSomIluminacaoContratante[ItensSomIluminacaoContratante.Count - 1].SubItens.Add(new DTO.SubItemEvento
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

			if (Evento.PosVendedora != null)
				pdf.AddLeadText("Pós-venda: " + Evento.PosVendedora.Nome + " - " + Evento.PosVendedora.Telefone);
			else
				pdf.AddLeadText("Responsável pós-venda: Indefinido.");
			if (Evento.Produtora != null)
				pdf.AddLeadText("Produção: " + Evento.Produtora.Nome + " - " + Evento.Produtora.Telefone + " - " + Evento.Produtora.Telefone);
			else
				pdf.AddLeadText("Responsável produção: Indefinido.");
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

			if (Evento.Cardapio != null)
				pdf.AddLeadText("Cardápio: " + Evento.Cardapio.Nome);
			else
				pdf.AddLeadText("Cardápio: Indefinido.");
			if (Evento.TipoServico != null)
				pdf.AddLeadText("Tipo de serviço: " + Evento.TipoServico.Nome);
			else
				pdf.AddLeadText("Tipo de serviço: Indefinido.");
			pdf.AddBreakRule();
			pdf.BreakPage();
		}
		private void AdicionarPaginaLayout()
		{
			Model.Foto layout = Fotos.FirstOrDefault(f => f.Qual == "EV");
			if (layout == null)
				return;
			pdf.BreakPage();
			pdf.AddHeader();
			pdf.AddLeadText("Layout do salão");
			pdf.AddBreakRule();

			pdf.AddImage(HttpContext.Current.Server.MapPath("~/Content/Images/" + layout.URL), layout.Legenda, true);
			pdf.BreakPage();
		}
		private void AdicionarPaginaBebidas()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Bebidas");
			pdf.AddBreakRule();

			if (ItensBebidaBisutti.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.ItemEvento grupo in ItensBebidaBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensBebidaBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensBebidaTerceiro.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.ItemEvento grupo in ItensBebidaTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensBebidaTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensBebidaContratante.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.ItemEvento grupo in ItensBebidaContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensBebidaContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}

			AdicionarFotosArea("BB");
			pdf.BreakPage();
		}
		private void AdicionarPaginaDecoracao()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Decoração da recepção");
			pdf.AddBreakRule();

			if (ItensDecoracaoBisutti.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.ItemEvento grupo in ItensDecoracaoBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensDecoracaoBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensDecoracaoTerceiro.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.ItemEvento grupo in ItensDecoracaoTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensDecoracaoTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensDecoracaoContratante.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.ItemEvento grupo in ItensDecoracaoContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensDecoracaoContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}

			AdicionarFotosArea("DR");
			pdf.BreakPage();
		}
		private void AdicionarPaginaDecoracaoCerimonial()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Decoração da cerimônia");
			pdf.AddBreakRule();

			if (ItensDecoracaoCerimonialBisutti.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.ItemEvento grupo in ItensDecoracaoCerimonialBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensDecoracaoCerimonialBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensDecoracaoCerimonialTerceiro.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.ItemEvento grupo in ItensDecoracaoCerimonialTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensDecoracaoCerimonialTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensDecoracaoCerimonialContratante.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.ItemEvento grupo in ItensDecoracaoCerimonialContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensDecoracaoCerimonialContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}

			AdicionarFotosArea("DC");
			pdf.BreakPage();
		}
		private void AdicionarPaginaFotoVideo()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Itens de Foto & Vídeo");
			pdf.AddBreakRule();

			if (ItensFotoVideoBisutti.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.ItemEvento grupo in ItensFotoVideoBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensFotoVideoBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensFotoVideoTerceiro.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.ItemEvento grupo in ItensFotoVideoTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensFotoVideoTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensFotoVideoContratante.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.ItemEvento grupo in ItensFotoVideoContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensFotoVideoContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}

			AdicionarFotosArea("FV");
			pdf.BreakPage();
		}
		private void AdicionarPaginaGastronomia(bool incluiDegustar)
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Gastronomia");
			pdf.AddBreakRule();
			foreach (DTO.ItemEvento grupo in ItensGastronomia.Where(i => i.SubItens.Where(si => !si.BloqueiaOutrasPropriedades).Count() > 0))
			{
				if (!incluiDegustar && grupo.SubItens.Where(si => si.Responsabilidade == true).Count() == 0)
					continue;
				pdf.AddLeadText(grupo.Texto + (incluiDegustar ? " (Escolher " + grupo.Quantidade + " ite" + (grupo.Quantidade > 1 ? "ns" : "m") + ")" : ""));
				pdf.BreakLine();
				foreach (DTO.SubItemEvento item in grupo.SubItens.OrderBy(i => i.NomeItem))
				{
					//BloqueiaOutrasPropriedades = item.Rejeitado,
					//Responsabilidade = item.Escolhido,
					//Fornecido = item.Degustar,
					if (item.BloqueiaOutrasPropriedades)
						continue;
					if ((item.Fornecido && incluiDegustar) || (item.Responsabilidade))
						pdf.AddLine(item.NomeItem);
				}
				pdf.AddLine(" ");
				pdf.BreakLine();
			}
			pdf.BreakPage();
		}
		private void AdicionarPaginaMontagem()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Montagem do Salão");
			pdf.AddBreakRule();

			if (ItensMontagemBisutti.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.ItemEvento grupo in ItensMontagemBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensMontagemBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensMontagemTerceiro.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.ItemEvento grupo in ItensMontagemTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensMontagemTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensMontagemContratante.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.ItemEvento grupo in ItensMontagemContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensMontagemContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}

			AdicionarFotosArea("MS");
			pdf.BreakPage();
		}
		private void AdicionarPaginaOutrosItens()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Outros itens");
			pdf.AddBreakRule();

			if (ItensOutrosItensBisutti.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.ItemEvento grupo in ItensOutrosItensBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensOutrosItensBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensOutrosItensTerceiro.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.ItemEvento grupo in ItensOutrosItensTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensOutrosItensTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensOutrosItensContratante.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.ItemEvento grupo in ItensOutrosItensContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensOutrosItensContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}

			AdicionarFotosArea("OI");
			pdf.BreakPage();
		}
		private void AdicionarPaginaSomIluminacao()
		{
			pdf.AddHeader();
			pdf.AddHeaderText("Itens de Som e Iluminação");
			pdf.AddBreakRule();

			if (ItensSomIluminacaoBisutti.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoBisutti, true);
				foreach (DTO.ItemEvento grupo in ItensSomIluminacaoBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensSomIluminacaoBisutti)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensSomIluminacaoTerceiro.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoTerceiro, true);
				foreach (DTO.ItemEvento grupo in ItensSomIluminacaoTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensSomIluminacaoTerceiro)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}
			if (ItensSomIluminacaoContratante.Count() > 0)
			{
				pdf.AddLine(Util.TextoFornecimentoContratante, true);
				foreach (DTO.ItemEvento grupo in ItensSomIluminacaoContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				foreach (DTO.ItemEvento grupo in CopiaItensSomIluminacaoContratante)
				{
					pdf.AddLeadText(grupo.Texto);
					foreach (DTO.SubItemEvento item in grupo.SubItens)
						pdf.AddLine(string.Format("{0} -> qtd: {1} -> {2}", item.NomeItem, item.QuantidadeItem, item.Observacao), false);
				}
				pdf.AddBreakRule();
			}

			AdicionarFotosArea("SI");
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
		private void AdicionarFotosArea(string qual)
		{
			foreach (Model.Foto foto in Fotos.Where(f => f.Qual == qual))
				pdf.AddImage(HttpContext.Current.Server.MapPath("~/Content/Images/" + foto.URL), foto.Legenda);
		}
		public void GerarOS()
		{
			InicializePDF();

			AdicionarPaginaPrincipal();
			AdicionarPaginaBebidas();
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
			AdicionarPaginaBebidas();
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
			ItensBebidaBisutti = null;
			ItensBebidaTerceiro = null;
			ItensBebidaContratante = null;
			ItensBoloTerceiro = null;
			ItensBoloContratante = null;
			ItensDecoracaoBisutti = null;
			ItensDecoracaoTerceiro = null;
			ItensDecoracaoContratante = null;
			ItensDecoracaoCerimonialBisutti = null;
			ItensDecoracaoCerimonialTerceiro = null;
			ItensDecoracaoCerimonialContratante = null;
			ItensFotoVideoBisutti = null;
			ItensFotoVideoTerceiro = null;
			ItensFotoVideoContratante = null;
			ItensMontagemBisutti = null;
			ItensMontagemTerceiro = null;
			ItensMontagemContratante = null;
			ItensOutrosItensBisutti = null;
			ItensOutrosItensTerceiro = null;
			ItensOutrosItensContratante = null;
			ItensSomIluminacaoBisutti = null;
			ItensSomIluminacaoTerceiro = null;
			ItensSomIluminacaoContratante = null;
			fotos = null;
			itensGastronomia = null;
		}
	}
}
