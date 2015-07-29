using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public abstract class DataAccessBase<T> where T : Model.IEntityBase
	{
		protected Context context
		{
			get
			{
				return VillaBisutti.Delta.Util.context;
			}
		}
		public T GetElement(int id = 0)
		{
			if (id == 0)
				return default(T);
			T entity = GetCollection(id).FirstOrDefault();
			return entity;
		}
		public List<T> GetCollection(int id)
		{
			return id != 0 ? GetCollection().Where(x => x.Id == id).ToList() : GetCollection().ToList();
		}
		public void Delete(int id)
		{
			T entity = GetElement(id);
			GetCurrent(entity).State = System.Data.Entity.EntityState.Deleted;
			context.SaveChanges();
		}
		public abstract void Update(T entity);
		public abstract DbEntityEntry GetCurrent(T entity);
		public abstract void Insert(T entity);
		protected abstract List<T> GetCollection();
	}
}
