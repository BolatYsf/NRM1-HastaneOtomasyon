using Hastane.Core.DataAccessAbstract;
using Hastane.Core.EntitiesAbstract;
using Hastane.Core.Enums;
using Hastane.DataAccess.EntityFramework.Context;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Concrete
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity
    {
        private readonly HastaneDbContext _hastaneDbContext; //parammetre olarak alacagım
        protected DbSet<T> _table;

        public BaseRepo(HastaneDbContext hastaneDbContext)
        {
            _hastaneDbContext = hastaneDbContext;
            _table = _hastaneDbContext.Set<T>();             //ibase repo tanımlıyorsun set burda gelen entity o tablosunu alıyor
        }

        public async Task<bool> Add(T entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> AddRange(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            return await Save() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            //sayfadan donecek ola ıd li veriyi istersen status deleted olarak cekebilirsin
            entity.Status = Core.Enums.Status.Passive;
           // _hastaneDbContext.Entry<T>(entity).State = EntityState.Deleted;
            return await Save() > 0;
        }

        //public async Task<List<T>> GetAll()
        //{
        //   return await _table.ToListAsync();
        //}

        public async Task<List<T>> GetAll() => await _table.Where(x => x.Status == Status.Active).ToListAsync();

        public async Task<T> GetById(Guid id) => await _table.FindAsync(id);
       

        public async Task<int> Save()
        {
            return await _hastaneDbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _hastaneDbContext.Entry<T>(entity).State = EntityState.Modified; //arkada orm state takip ediyor 
            return await Save() > 0;
                
        }

        
    }
}
