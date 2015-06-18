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
		{ }
		public DbSet<Model.Area> Areas { get; set; }
		public DbSet<Model.Bebida> Bebidas { get; set; }
		public DbSet<Model.ItemBoloDoceBemCasadoSelecionado> BolosDocesBemCasados { get; set; }
		public DbSet<Model.ContratoAditivo> ContratosAdivitivos { get; set; }
		public DbSet<Model.CronogramaCerimonial> CronogramasCerimoniais { get; set; }
		public DbSet<Model.CronogramaCerimonialPadrao> CronogramasCerimoniaisPadroes { get; set; }
		public DbSet<Model.ItemDecoracaoSelecionado> Decoracoes { get; set; }
		public DbSet<Model.ItemFotoVideoSelecionado> FotosVideos { get; set; }
		public DbSet<Model.ItemGastronomiaSelecionado> Gastronomias { get; set; }
		public DbSet<Model.ItemBebida> ItensBebidas { get; set; }
		public DbSet<Model.ItemBoloDoceBemCasado> ItensBolosDocesBemCasados { get; set; }
		public DbSet<Model.ItemDecoracao> ItensDecoracoes { get; set; }
		public DbSet<Model.ItemFotoVideo> ItensFotosVideos { get; set; }
		public DbSet<Model.ItemGastronomia> ItensGastronomias { get; set; }
		public DbSet<Model.ItemMontagem> ItensMontagens { get; set; }
		public DbSet<Model.ItemOutroItemItemDiverso> IntensOutrosItensItensDiversos { get; set; }
		public DbSet<Model.ItemSomIluminacao> ItensSonsIluminacoes { get; set; }
		public DbSet<Model.ItemMontagemSelecionado> Montagens { get; set; }
		public DbSet<Model.OutroItem> OutrosItens { get; set; }
		public DbSet<Model.PerfilUsuarioSistema> PerfilsUsuariosSistemas { get; set; }
		public DbSet<Model.Roteiro> Roteiros { get; set; }
		public DbSet<Model.RoteiroPadrao> RoteirosPadroes { get; set; }
		public DbSet<Model.ItemSomIluminacaoSelecionado> SonsIluminacoes { get; set; }
		public DbSet<Model.TipoItemBoloDoceBemCasado> TiposItensBolosDocesBemCasados { get; set; }
		public DbSet<Model.TipoItemDecoracao> TiposItensDecoracoes { get; set; }
		public DbSet<Model.TipoItemFotoVideo> TiposItensFotosVideos { get; set; }
		public DbSet<Model.TipoItemGastronomia> TiposItensGastronomias { get; set; }
		public DbSet<Model.TipoItemMontagem> TiposItemMontagens { get; set; }
		public DbSet<Model.TipoItemOutroItemItemDiverso> TiposItensOutrosItensItensDiversos { get; set; }
		public DbSet<Model.TipoItemSomIluminacao> TiposItensSonsIluminacoes { get; set; }
		public DbSet<Model.Usuario> Usuarios { get; set; }

	}
}
