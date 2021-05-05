using HospitalAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Core.Specification
{
    public class BranchWithOrderBySpecification : BaseSpecification<Branch>
    {
        public BranchWithOrderBySpecification(string sort, string district, bool? isactive, string search) 
            : base(x =>
                (string.IsNullOrEmpty(search) || x.Name.Contains(search)) &&
                (string.IsNullOrEmpty(district) || x.District == district) &&
                (!isactive.HasValue || x.IsActive == isactive))
        {

            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {

                    case "nameAsc":
                        AddOrderBy(x => x.Name);
                        break;
                    case "nameDsc":
                        AddOrderByDescending(x => x.Name);
                        break;
                    default:
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
        }

        public BranchWithOrderBySpecification(int id) : base(x => x.Id == id)
        {

        }
    }
}
