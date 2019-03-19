using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SistemaGerenciamento.Domain.ComponentInterfaces;

using SistemaGerenciamento.EntityFramework.Conections;

namespace SistemaGerenciamento.EntityFramework.Persistence
{
    public class BaseContext<Entity> : IBaseContext<Entity>
        where Entity : class
    {
        protected readonly Conection conection;

        public BaseContext(Conection conection)
        {
            this.conection = conection;
        }

        public void Insert(Entity obj)
        {
            conection.Add(obj);
        }

        public void Insert(IEnumerable<Entity> objs)
        {
            conection.AddRange(objs);
        }

        public void Update(Entity item, params Expression<Func<Entity, object>>[] expressions)
        {
            var x = this.conection.Attach(item);
            foreach (var expression in expressions)
            {
                x.Property(expression).IsModified = true;
            }
        }

        public void Update(Entity obj)
        {
            conection.Update(obj);
        }

        public void Update(IEnumerable<Entity> objs)
        {
            conection.UpdateRange(objs);
        }

        public void Delete(Entity obj)
        {
            conection.Remove(obj);
        }

        public void Delete(IEnumerable<Entity> objs)
        {
            conection.RemoveRange(objs);
        }

        public int SaveChanges()
        {
            return conection.SaveChanges();
        }
    }
}
