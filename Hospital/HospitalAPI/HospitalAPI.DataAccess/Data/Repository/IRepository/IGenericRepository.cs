using HospitalAPI.Core.Models;
using HospitalAPI.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.DataAccess.Data.Repository.IRepository
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsyncWithSpec(ISpecification<T> spec);
    }
}
