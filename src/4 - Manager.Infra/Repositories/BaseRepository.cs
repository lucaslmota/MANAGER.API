using System.Linq;
using Manager.Infra.Context;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ManagerContext _contexte;

        public BaseRepository(ManagerContext context)
        {
            _contexte = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _contexte.Add(obj);
            await _contexte.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _contexte.Entry(obj).State = EntityState.Modified;

            await _contexte.SaveChangesAsync();
            return obj;
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if(obj != null){
                _contexte.Remove(obj);
                await _contexte.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = await _contexte.Set<T>()
                                     .AsNoTracking()
                                     .Where(x => x.Id == id)
                                     .ToListAsync();
            
            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _contexte.Set<T>()
                                  .AsNoTracking()
                                  .ToListAsync();
        }

    }
}