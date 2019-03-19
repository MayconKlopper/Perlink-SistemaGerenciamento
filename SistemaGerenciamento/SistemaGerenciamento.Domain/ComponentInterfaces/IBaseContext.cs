using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SistemaGerenciamento.Domain.ComponentInterfaces
{
    public interface IBaseContext<Entity> where Entity : class
    {
        void Insert(Entity obj);

        void Insert(IEnumerable<Entity> objs);

        void Update(Entity item, params Expression<Func<Entity, object>>[] expressions);

        void Update(Entity obj);

        void Update(IEnumerable<Entity> objs);

        void Delete(Entity obj);

        void Delete(IEnumerable<Entity> objs);

        int SaveChanges();
    }
}
