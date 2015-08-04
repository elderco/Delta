using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Data
{
	public class Reuniao : DataAccessBase<Model.Reuniao>
	{
		//TODO: Implementar os métodos abaixo (Gabriel)
		public override void Update(Model.Reuniao entity)
		{
			Model.Reuniao reuniao = context.Reuniao.FirstOrDefault(s => s.Id.Equals(entity.Id));
			context.Entry(reuniao).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Reuniao entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Reuniao entity)
		{
			context.Reuniao.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Reuniao> GetCollection()
		{
			return context.Reuniao.Include(r => r.TipoReuniao).Include(r => r.Usuario).ToList();
		}
		public List<Model.Reuniao> ReunioesEvento(int eventoId)
		{
			return GetCollection().Where(r => r.EventoId == eventoId).ToList();
		}
		public List<Model.Reuniao> ReunioesUsuario(int usuarioId)
		{
			return context.Reuniao
				.Include(r => r.Evento)
				.Include(r => r.Evento.TipoEvento)
				.Include(r => r.Evento.Local)
				.Include(r => r.TipoReuniao)
				.Include(r => r.Usuario)
				.Where(r => r.UsuarioId == usuarioId).ToList();
		}
	}
}
