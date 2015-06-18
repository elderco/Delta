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
		public DbSet<Model.BoloDoceBemCasado> BoloDoceBemCasado { get; set; }
		public DbSet<Model.ContratoAditivo> ContratoAdivitivo { get; set; }
		public DbSet<Model.CronogramaCerimonial> CronogramaCerimonial { get; set; }
		public DbSet<Model.CronogramaCerimonialPadrao> CronogramaCerimonialPadrao { get; set; }
		public DbSet<Model.Decoracao> Decoracao { get; set; }
		public DbSet<Model.FotoVideo> FotoVideo { get; set; }
		public DbSet<Model.Gastronomia> Gastronomia { get; set; }
		public DbSet<Model.ItemBebida> ItemBebida { get; set; }
		public DbSet<Model.ItemBebidaSelecionado> ItemBebidaSelecionado { get; set; }
		public DbSet<Model.ItemBoloDoceBemCasado> ItemBoloDoceBemCasado { get; set; }
		public DbSet<Model.ItemDecoracao> ItemDecoracao { get; set; }
		public DbSet<Model.ItemFotoVideo> ItemFotoVideo { get; set; }
		public DbSet<Model.ItemGastronomia> ItemGastronomia { get; set; }
		public DbSet<Model.ItemMontagem> ItemMontagem { get; set; }
		public DbSet<Model.ItemOutroItem> ItemOutroItem { get; set; }
		public DbSet<Model.ItemSomIluminacao> ItemSomIluminacao { get; set; }
		public DbSet<Model.Montagem> Montagem { get; set; }
		public DbSet<Model.OutroItem> OutroItem { get; set; }
		public DbSet<Model.PerfilUsuarioSistema> PerfilUsuarioSistema { get; set; }
		public DbSet<Model.Roteiro> Roteiro { get; set; }
		public DbSet<Model.RoteiroPadrao> RoteiroPadrao { get; set; }
		public DbSet<Model.SomIluminacao> SomIluminacao { get; set; }
		public DbSet<Model.TipoItemBoloDoceBemCasado> TipoItemBoloDoceBemCasado { get; set; }
		public DbSet<Model.TipoItemDecoracao> TipoItemDecoracao { get; set; }
		public DbSet<Model.TipoItemFotoVideo> TipoItemFotoVideo { get; set; }
		public DbSet<Model.TipoItemGastronomia> TipoItemGastronomia { get; set; }
		public DbSet<Model.TipoItemMontagem> TipoItemMontagem { get; set; }
		public DbSet<Model.TipoItemOutroItem> TipoItemOutroItem { get; set; }
		public DbSet<Model.TipoItemSomIluminacao> TipoItemSomIluminacao { get; set; }
		public DbSet<Model.Usuario> Usuario { get; set; }

	}
}
