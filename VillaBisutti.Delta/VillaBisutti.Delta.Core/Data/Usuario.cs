using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Usuario : DataAccessBase<Model.Usuario>
	{
		public override void Update(Model.Usuario entity)
		{
			throw new NotImplementedException();
		}

		public override DbEntityEntry GetCurrent(Model.Usuario entity)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Model.Usuario entity)
		{
			throw new NotImplementedException();
		}

		protected override List<Model.Usuario> GetCollection()
		{
			throw new NotImplementedException();
		}
	}
}
