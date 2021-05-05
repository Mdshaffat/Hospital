using HospitalAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Core.Specification
{
    public class SpecificationEvaluator<T> where T : ModelBase
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null )
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderBydesc != null)
            {
                query = query.OrderByDescending(spec.OrderBydesc);
            }


            //query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));


            return query;
        }
    }
}
