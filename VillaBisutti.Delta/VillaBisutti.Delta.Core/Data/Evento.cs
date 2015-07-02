using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class Evento : DataAccessBase<Model.Evento>
	{
		public override void Update(Model.Evento entity)
		{
			Model.Evento original = context.Evento.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Evento entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Evento entity)
		{
			context.Evento.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Evento> GetCollection()
		{
			return context.Evento
					.Include(e => e.Bebida)
					.Include(e => e.BoloDoceBemCasado)
					.Include(e => e.Cardapio)
					.Include(e => e.Decoracao)
					.Include(e => e.FotoVideo)
					.Include(e => e.Local)
					.Include(e => e.Montagem)
					.Include(e => e.OutrosItens)
					.Include(e => e.PosVendedora)
					.Include(e => e.Produtora)
					.Include(e => e.SomIluminacao)
					.ToList();
			
		}
		public List<Model.Evento> GetEventos(int casaId, int produtorId)
		{
			return context.Evento.Where(e =>
				e.LocalId == casaId && e.ProdutoraId == produtorId
				).ToList();
		}

        public List<Model.Evento> GetEventosServicoTerceiro()
        {
            return context.Evento
                .Include(e => e.Decoracao).Include(e => e.Decoracao.Itens)
                .Include(e => e.Montagem).Include(e => e.Montagem.Itens)
                .Include(e => e.Bebida).Include(e => e.Bebida.Itens)
                .Include(e => e.BoloDoceBemCasado).Include(e => e.BoloDoceBemCasado.Itens)
                .Include(e => e.FotoVideo).Include(e => e.FotoVideo.Itens)
                .Include(e => e.SomIluminacao).Include(e => e.SomIluminacao.Itens)
                .Include(e => e.OutrosItens).Include(e => e.OutrosItens.Itens)
                 //.Where((i => i.ContratacaoBisutti == true && i.FornecimentoBisutti == false && i.Definido == true && i.FornecedorStartado == false))
                    //.Where(i => i.ContratacaoBisutti == true && i.FornecimentoBisutti == false && i.Definido == true && i.FornecedorStartado == false)
                    //.Where(i => i.ContratacaoBisutti == true && i.FornecimentoBisutti == false && i.Definido == true && i.FornecedorStartado == false)
                    //.Where(i => i.ContratacaoBisutti == true && i.FornecimentoBisutti == false && i.Definido == true && i.FornecedorStartado == false)
                    //.Where(i => i.ContratacaoBisutti == true && i.FornecimentoBisutti == false && i.Definido == true && i.FornecedorStartado == false)
                    //.Where(i => i.ContratacaoBisutti == true && i.FornecimentoBisutti == false && i.Definido == true && i.FornecedorStartado == false)
                    //.Where(i => i.ContratacaoBisutti == true && i.FornecimentoBisutti == false && i.Definido == true && i.FornecedorStartado == false)
                .ToList();
                
        }
	}
}
