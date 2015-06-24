using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Context : DbContext
	{
		public Context()
			: base("VillaBisuttiDelta")
		{
			Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());

		}
		public DbSet<Model.ItemBebidaSelecionado> ItemBebidaSelecionado { get; set; }
		public DbSet<Model.ItemBoloDoceBemCasadoSelecionado> BoloDoceBemCasado { get; set; }
		public DbSet<Model.ContratoAditivo> ContratoAdivitivo { get; set; }
		public DbSet<Model.CronogramaCerimonial> CronogramaCerimonial { get; set; }
		public DbSet<Model.CronogramaCerimonialPadrao> CronogramaCerimonialPadrao { get; set; }
		public DbSet<Model.ItemDecoracaoSelecionado> Decoracao { get; set; }
		public DbSet<Model.ItemFotoVideoSelecionado> FotoVideo { get; set; }
		public DbSet<Model.ItemBebida> ItemBebida { get; set; }
		public DbSet<Model.ItemBoloDoceBemCasado> ItemBoloDoceBemCasado { get; set; }
		public DbSet<Model.ItemDecoracao> ItemDecoracao { get; set; }
		public DbSet<Model.ItemFotoVideo> ItemFotoVideo { get; set; }
		public DbSet<Model.ItemMontagem> ItemMontagem { get; set; }
		public DbSet<Model.ItemOutrosItens> ItemOutrosItens { get; set; }
		public DbSet<Model.ItemSomIluminacao> ItemSomIluminacao { get; set; }
		public DbSet<Model.ItemMontagemSelecionado> ItemMontagemSelecionado { get; set; }
		public DbSet<Model.OutroItem> OutroItem { get; set; }
		public DbSet<Model.PerfilUsuarioSistema> PerfilUsuarioSistema { get; set; }
		public DbSet<Model.Roteiro> Roteiro { get; set; }
		public DbSet<Model.RoteiroPadrao> RoteiroPadrao { get; set; }
		public DbSet<Model.ItemSomIluminacaoSelecionado> ItemSomIluminacaoSelecionado { get; set; }
		public DbSet<Model.TipoItemBebida> TipoItemBebida { get; set; }
		public DbSet<Model.TipoItemBoloDoceBemCasado> TipoItemBoloDoceBemCasado { get; set; }
		public DbSet<Model.TipoItemDecoracao> TipoItemDecoracao { get; set; }
		public DbSet<Model.TipoItemFotoVideo> TipoItemFotoVideo { get; set; }
		public DbSet<Model.TipoItemMontagem> TipoItemMontagem { get; set; }
		public DbSet<Model.TipoItemOutrosItens> TipoItemOutrosItens { get; set; }
		public DbSet<Model.TipoItemSomIluminacao> TipoItemSomIluminacao { get; set; }
		public DbSet<Model.Usuario> Usuario { get; set; }
		public DbSet<Model.Evento> Evento { get; set; }
		public DbSet<Model.CardapioPadrao> CardapioPadrao { get; set; }
		public DbSet<Model.Cardapio> Cardapio { get; set; }
        public DbSet<Model.Prato> Prato{ get; set; }
        public DbSet<Model.TipoPrato> TipoPrato { get; set; }
        public DbSet<Model.PratoSelecionado> PratoSelecionado { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Model.Evento>()
				.HasRequired(e => e.Produtora)
				.WithMany()
				.WillCascadeOnDelete(false);
			modelBuilder.Entity<Model.Evento>()
				.HasRequired(e => e.PosVendedora)
				.WithMany()
				.WillCascadeOnDelete(false);
		}

	}
}
