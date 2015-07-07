using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemBebida : DataAccessBase<Model.TipoItemBebida>
	{
		public override void Update(Model.TipoItemBebida entity)
		{
			//context.TipoItemBebida.Attach(entity);
			//context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
			//context.SaveChanges();
			Model.TipoItemBebida original = context.TipoItemBebida.Find(entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}
		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemBebida entity)
		{
			return context.Entry(entity);
		}
		public override void Insert(Model.TipoItemBebida entity)
		{
			context.TipoItemBebida.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemBebida> GetCollection()
		{
			return context.TipoItemBebida.ToList();
		}
		public List<Model.TipoItemBebida> ListNaoSelecionados(int id)
		{
			List<Model.TipoItemBebida> aniversario = context.TipoItemBebida.Where(tib => tib.PadraoAniversario).ToList();
			List<Model.TipoItemBebida> barmitzva = context.TipoItemBebida.Where(tib => tib.PadraoBarmitzva).ToList();
			List<Model.TipoItemBebida> batmitzva = context.TipoItemBebida.Where(tib => tib.PadraoBatmitzva).ToList();
			List<Model.TipoItemBebida> casamento = context.TipoItemBebida.Where(tib => tib.PadraoCasamento).ToList();
			List<Model.TipoItemBebida> corporativo = context.TipoItemBebida.Where(tib => tib.PadraoCorporativo).ToList();
			List<Model.TipoItemBebida> debutante = context.TipoItemBebida.Where(tib => tib.PadraoDebutante).ToList();
			List<Model.TipoItemBebida> outro = context.TipoItemBebida.Where(tib => tib.PadraoOutro).ToList();
			Model.TipoEvento tipo = new Evento().GetElement(id).TipoEvento;
			switch(tipo)
			{
				case Model.TipoEvento.Aniversario :
					return aniversario.Except(
						GetTipoItensPreenchidos(id)
						).ToList();
				case Model.TipoEvento.Barmitzva :
					return barmitzva.Except(
						GetTipoItensPreenchidos(id)
						).ToList();
				case Model.TipoEvento.Batmitzva:
					return batmitzva.Except(
						GetTipoItensPreenchidos(id)
						).ToList();
				case Model.TipoEvento.Casamento:
					return casamento.Except(
						GetTipoItensPreenchidos(id)
						).ToList();
				case Model.TipoEvento.Corporativo:
					return corporativo.Except(
						GetTipoItensPreenchidos(id)
						).ToList();
				case Model.TipoEvento.Debutante:
					return debutante.Except(
						GetTipoItensPreenchidos(id)
						).ToList();
				case Model.TipoEvento.Outro:
					return outro.Except(
						GetTipoItensPreenchidos(id)
						).ToList();
			}
			return null;
		}
		private IQueryable<Model.TipoItemBebida> GetTipoItensPreenchidos(int id)
		{
			return context.ItemBebidaSelecionado.Include(ibs => ibs.ItemBebida).Include(ibs => ibs.ItemBebida.TipoItemBebida)
										.Where(ibs => ibs.BebidaId == id).Select(ibs => ibs.ItemBebida.TipoItemBebida);
		}
	}
}
