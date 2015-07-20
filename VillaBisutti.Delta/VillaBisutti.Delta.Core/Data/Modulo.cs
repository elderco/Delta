using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
    public class Modulo : DataAccessBase<Model.Modulo>
    {
        public override void Update(Model.Modulo entity)
        {
            return;
        }

        public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Modulo entity)
        {
            return null;
        }

        public override void Insert(Model.Modulo entity)
        {
            return;
        }

        protected override List<Model.Modulo> GetCollection()
        {
            return context.Modulo.ToList();
        }
    }
}
