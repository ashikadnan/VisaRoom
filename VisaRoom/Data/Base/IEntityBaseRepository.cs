﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VisaRoom.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByCandidateIdAsync(int id, params Expression<Func<T, object>>[] includeproperties);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
