﻿using FLMS.Data.Common.Models;
using FLMS.Data.Common.Repository;
using FLMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLMS.Data
{
    public class FlmsData : IFlmsData
    {
        private readonly IFlmsDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public FlmsData(IFlmsDbContext context)
        {
            this.context = context;
        }

        public IFlmsDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        //public IRepository<T> GetGenericRepository<T>() where T : class
        //{
        //    if (typeof(T).IsAssignableFrom(typeof(DeletableEntity)))
        //    {
        //        return this.GetDeletableEntityRepository<T>();
        //    }
        //    return this.GetRepository<T>();
        //}
        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IDeletableEntityRepository<Player> Players
        {
            get
            {
                return this.GetDeletableEntityRepository<Player>();
            }
        }
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }
            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }
            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}