﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
    public class Prato : DataAccessBase<Model.Prato>
    {
        public override void Update(Model.Prato entity)
        {
            Model.Prato original = context.Prato.FirstOrDefault(x => x.Id.Equals(entity.Id));
            context.Entry(original).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Prato entity)
        {
            return context.Entry(entity);
        }

        public override void Insert(Model.Prato entity)
        {
            context.Prato.Add(entity);
        }

        protected override List<Model.Prato> GetCollection()
        {
            return context.Prato.ToList();
        }
    }
}
