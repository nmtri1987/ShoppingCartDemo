﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NT.Core;

namespace NT.Infrastructure
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly AppDbContext DbContext;

        public EfRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<TEntity>()
                .SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity>[] specs)
        {
            var ret = DbContext.Set<TEntity>();
            IQueryable<TEntity> rett = null;
            foreach (var spec in specs)
            {
                rett = ret.Include(spec.Include).Where(spec.Criteria);
            }

            return await rett.ToListAsync();
        }
    }
}