using HospitalAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.DataAccess.Data.Repository.IRepository
{
    public interface IBranchRepository
    {
        Task<Branch> GetBranchByIdAsync(int id);
        Task<IReadOnlyList<Branch>> GetBranchesAsync();

        Task<ActionResult<Branch>> PostBranchAsync(Branch branch);
        Task<ActionResult<IReadOnlyList<Branch>>> DeleteBranchAsync(int id);
        Task<ActionResult<Branch>> PutBranchAsync(int id, Branch branch);
    }
}
