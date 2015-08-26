using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Business
{
	public class Evento
	{
		public Data.Context context
		{
			get
			{
				return Util.context;
			}
		}
		public void CopiarRoteiroPadrao(Model.Evento evento)
		{
			if (evento.Roteiro == null)
				evento.Roteiro = new List<Model.ItemRoteiro>();
			foreach (Model.ItemRoteiro item in context.ItemRoteiro.Where(rp => rp.TipoEvento == evento.TipoEvento && (rp.EventoId == 0 || rp.EventoId == null)))
				context.ItemRoteiro.Add(new Model.ItemRoteiro
				{
					EventoId = evento.Id,
					Titulo = item.Titulo,
					HorarioInicio = evento.HorarioInicio + item.HorarioInicio,
					Observacao = item.Observacao
				});
			context.SaveChanges();
		}
		public void CopiarCerimonialPadrao(Model.Evento evento)
		{
			if (evento.Cerimonial == null)
				evento.Cerimonial = new List<Model.ItemCerimonial>();
			foreach (Model.ItemCerimonial item in context.ItemCerimonial.Where(rp => rp.TipoEvento == evento.TipoEvento && (rp.EventoId == 0 || rp.EventoId == null)))
				context.ItemCerimonial.Add(new Model.ItemCerimonial
				{
					EventoId = evento.Id,
					Titulo = item.Titulo,
					HorarioInicio = evento.HorarioInicio + item.HorarioInicio,
					Observacao = item.Observacao
				});
			context.SaveChanges();
		}
		public void CopiarCardapioPadrao(Model.Evento evento)
		{
			if (evento.CardapioId == 0 || evento.TipoServicoId == 0)
				return;
			if (evento.Gastronomia.Pratos == null)
				evento.Gastronomia.Pratos = new List<Model.PratoSelecionado>();
			if (evento.Gastronomia.TiposPratos == null)
				evento.Gastronomia.TiposPratos = new List<Model.TipoPratoPadrao>();
			List<Model.PratoSelecionado> pratos = context.PratoSelecionado.Where(ps => ps.EventoId == evento.Id).ToList();
			foreach (Model.PratoSelecionado prato in context.PratoSelecionado.Where(p => p.EventoId == null && p.CardapioId == evento.CardapioId && p.TipoServicoId == evento.TipoServicoId))
				if (pratos.Where(p => p.PratoId == prato.PratoId).Count() <= 0)
					context.PratoSelecionado.Add(new Model.PratoSelecionado
					{
						EventoId = evento.Id,
						PratoId = prato.PratoId,
						Degustar = prato.Degustar,
						Escolhido = false,
						Rejeitado = false

					});
			List<Model.TipoPratoPadrao> tipos = context.TipoPratoPadrao.Where(tps => tps.EventoId == evento.Id).ToList();
			foreach (Model.TipoPratoPadrao tipo in context.TipoPratoPadrao.Where(p => p.EventoId == null && p.CardapioId == evento.CardapioId && p.TipoServicoId == evento.TipoServicoId))
				if (tipos.Where(t => t.TipoPratoId == tipo.TipoPratoId).Count() <= 0)
					context.TipoPratoPadrao.Add(new Model.TipoPratoPadrao
					{
						EventoId = evento.Id,
						TipoPratoId = tipo.TipoPratoId,
						QuantidadePratos = tipo.QuantidadePratos
					});
			context.SaveChanges();
		}
		public void CriarEvento(Model.Evento evento)
		{
			evento.Bebida = new Model.Bebida();
			evento.BoloDoceBemCasado = new Model.BoloDoceBemCasado();
			evento.Decoracao = new Model.Decoracao();
			evento.DecoracaoCerimonial = new Model.DecoracaoCerimonial();
			evento.FotoVideo = new Model.FotoVideo();
			evento.Gastronomia = new Model.Gastronomia();
			evento.Montagem = new Model.Montagem();
			evento.OutrosItens = new Model.OutrosItens();
			evento.SomIluminacao = new Model.SomIluminacao();
			context.Evento.Add(evento);
			context.SaveChanges();
			CopiarRoteiroPadrao(evento);
			CopiarCerimonialPadrao(evento);
			CopiarCardapioPadrao(evento);
		}
		public void AcionarEventosTerceiros()
		{
			List<Model.Evento> eventos = new Data.Evento().GetEventosServicoTerceiro();
		}
		public static void GerarOS(int id)
		{
			IEnumerable<Model.ItemBebidaSelecionado> itensBebida = Util.context.ItemBebidaSelecionado
				.Include(i => i.ItemBebida)
				.Include(i => i.ItemBebida.TipoItemBebida)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemBebida.Nome)
				.OrderBy(i => i.ItemBebida.TipoItemBebida.Ordem);
			IEnumerable<Model.ItemBoloDoceBemCasadoSelecionado> itensBolo = Util.context.ItemBoloDoceBemCasadoSelecionado
				.Include(i => i.ItemBoloDoceBemCasado)
				.Include(i => i.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemBoloDoceBemCasado.Nome)
				.OrderBy(i => i.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Ordem);
			IEnumerable<Model.ItemDecoracaoSelecionado> itensDecoracao = Util.context.ItemDecoracaoSelecionado
				.Include(i => i.ItemDecoracao)
				.Include(i => i.ItemDecoracao.TipoItemDecoracao)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemDecoracao.Nome)
				.OrderBy(i => i.ItemDecoracao.TipoItemDecoracao.Ordem);
			IEnumerable<Model.ItemDecoracaoCerimonialSelecionado> itensDecoracaoCerimonial = Util.context.ItemDecoracaoCerimonialSelecionado
				.Include(i => i.ItemDecoracaoCerimonial)
				.Include(i => i.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemDecoracaoCerimonial.Nome)
				.OrderBy(i => i.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Ordem);
			IEnumerable<Model.ItemFotoVideoSelecionado> itensFotoVideo = Util.context.ItemFotoVideoSelecionado
				.Include(i => i.ItemFotoVideo)
				.Include(i => i.ItemFotoVideo.TipoItemFotoVideo)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemFotoVideo.Nome)
				.OrderBy(i => i.ItemFotoVideo.TipoItemFotoVideo.Ordem);
			IEnumerable<Model.PratoSelecionado> itensGastronomia = Util.context.PratoSelecionado
				.Include(i => i.Prato)
				.Include(i => i.Prato.TipoPrato)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.Prato.Nome)
				.OrderBy(i => i.Prato.TipoPrato.Ordem);
			IEnumerable<Model.ItemMontagemSelecionado> itensMontagem = Util.context.ItemMontagemSelecionado
				.Include(i => i.ItemMontagem)
				.Include(i => i.ItemMontagem.TipoItemMontagem)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemMontagem.Nome)
				.OrderBy(i => i.ItemMontagem.TipoItemMontagem.Ordem);
			IEnumerable<Model.ItemOutrosItensSelecionado> itensOutrosItens = Util.context.ItemOutrosItensSelecionado
				.Include(i => i.ItemOutrosItens)
				.Include(i => i.ItemOutrosItens.TipoItemOutrosItens)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemOutrosItens.Nome)
				.OrderBy(i => i.ItemOutrosItens.TipoItemOutrosItens.Ordem);
			IEnumerable<Model.ItemSomIluminacaoSelecionado> itensSomIluminacao = Util.context.ItemSomIluminacaoSelecionado
				.Include(i => i.ItemSomIluminacao)
				.Include(i => i.ItemSomIluminacao.TipoItemSomIluminacao)
				.Where(i => i.EventoId == id)
				.OrderBy(i => i.ItemSomIluminacao.Nome)
				.OrderBy(i => i.ItemSomIluminacao.TipoItemSomIluminacao.Ordem);
			Model.Evento evento = Util.context.Evento
				.Include(e => e.Roteiro)
				.Include(e => e.Cerimonial)
				.Include(e => e.Local)
				.Include(e => e.Produtora)
				.Include(e => e.PosVendedora)
				.Include(e => e.Cardapio)
				.Include(e => e.TipoServico)
				.FirstOrDefault(e => e.Id == id);
			IEnumerable<Model.Foto> fotos = Util.context.Foto.Where(f => f.EventoId == id);
			PDF pdf = new PDF(Util.GetPDFName(evento));
			pdf.PrepareForWriting();
			pdf.SetHeader(evento.Data, evento.Local.NomeCasa, evento.TipoEvento.GetDescription(), evento.NomeHomenageados, evento.Pax,
				string.Format("Das {0} às {1}", evento.Inicio.ToString(), evento.Termino.ToString()), evento.LocalCerimonia.GetDescription(),
				evento.Produtora.Nome, evento.Produtora.Telefone, evento.PossuiAssessoria ? "Sim" : "Não", evento.ContatoAssessoria,
				evento.NomeResponsavel, evento.TelefoneContato, evento.PerfilFesta);

			pdf.AddHeader();

			pdf.AddLeadText(evento.NomeHomenageados);
			pdf.AddLine("Contato: " + evento.NomeResponsavel + " - " + evento.EmailContato + " - " + evento.TelefoneContato);
			pdf.AddLine("CPF: " + evento.CPFResponsavel);
			pdf.AddLine("Observações: " + evento.Observacoes);
			pdf.AddLine("Perfil da festa: " + evento.PerfilFesta);
			pdf.AddBreakRule();

			pdf.AddLeadText("Pós-venda: " + evento.PosVendedora.Nome + " - " + evento.PosVendedora.Telefone);
			pdf.AddLeadText("Produção: " + evento.Produtora.Nome + " - " + evento.Produtora.Telefone + " - " + evento.Produtora.Telefone);
			pdf.AddLeadText("Possui assessoria? " + (evento.PossuiAssessoria ? "Sim" : "Não"));
			if (evento.PossuiAssessoria)
				pdf.AddLine("Contato: " + evento.ContatoAssessoria);
			pdf.AddBreakRule();

			pdf.AddLeadText("Tipo de evento: " + evento.TipoEvento.GetDescription());
			pdf.AddLeadText("Local: " + evento.Local.NomeCasa);
			pdf.AddLine(evento.Local.EnderecoCasa);
			pdf.AddLeadText("Data: " + evento.Data.ToString("dddd, dd/MM/yyyy") + ", das " + evento.Inicio.ToString() + " às " + evento.Termino.ToString());
			pdf.AddLeadText("Pax: " + evento.Pax + " (+10%: " + (evento.Pax * 1.1) + ") pessoas.");
			pdf.AddLeadText("Cerimonial: " + evento.LocalCerimonia.GetDescription());
			if (!string.IsNullOrEmpty(evento.EnderecoCerimonia))
				pdf.AddLine(evento.EnderecoCerimonia);
			if (!string.IsNullOrEmpty(evento.ObservacoesCerimonia))
				pdf.AddLine(evento.ObservacoesCerimonia);
			pdf.AddBreakRule();

			pdf.AddLeadText("Cardápio: " + evento.Cardapio.Nome);
			pdf.AddLeadText("Tipo de serviço: " + evento.TipoServico.Nome);
			pdf.AddBreakRule();

			foreach (Model.ItemBebidaSelecionado item in itensBebida)
			{
			}
		}

	}
}
