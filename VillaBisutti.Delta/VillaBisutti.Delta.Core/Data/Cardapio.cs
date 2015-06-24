using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
    public class Cardapio : DataAccessBase<Model.Cardapio>
    {
        public override void Update(Model.Cardapio entity)
        {
            Model.Cardapio original = context.Cardapio.FirstOrDefault(s => s.Id.Equals(entity.Id));
            context.Entry(original).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Cardapio entity)
        {
            return context.Entry(entity);
        }

        public override void Insert(Model.Cardapio entity)
        {
            context.Cardapio.Add(entity);
        }

        protected override List<Model.Cardapio> GetCollection()
        {
            return context.Cardapio.ToList();
        }
    }
}
