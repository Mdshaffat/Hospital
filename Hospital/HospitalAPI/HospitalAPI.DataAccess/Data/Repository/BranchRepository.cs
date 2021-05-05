using HospitalAPI.Core.Models;
using HospitalAPI.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.DataAccess.Data.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _context;

        public BranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Branch>> GetBranchesAsync()
        {
            return await _context.Branch.ToListAsync();
        }
        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            var branch = _context.Branch.FirstOrDefaultAsync(b => b.Id == id);
            return await branch;
        }

        public async Task<ActionResult<Branch>> PostBranchAsync(Branch branch)
        {
            branch.UpdatedOn = DateTime.Now;
            branch.CreatedOn = DateTime.Now;
           _context.Branch.Add(branch);
           await _context.SaveChangesAsync();

            return branch;
        }


        public async Task<ActionResult<Branch>> PutBranchAsync(int id, Branch branch)
        {
            var branchById = await _context.Branch.FirstOrDefaultAsync(b => b.Id == id);

            branchById.Name = branch.Name;
            branchById.Address = branch.Address;
            branchById.District = branch.District;
            branchById.UpdatedBy = branch.UpdatedBy;
            branchById.UpdatedOn = DateTime.Now;
            branchById.Upazila = branch.Upazila;
            branchById.IsActive = branch.IsActive;
            _context.Branch.Update(branchById);
            await _context.SaveChangesAsync();

            return branchById;
                
        }

        public async Task<ActionResult<IReadOnlyList<Branch>>> DeleteBranchAsync(int id)
        {
            var branch = await _context.Branch.FindAsync(id);
            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();

            return await _context.Branch.ToListAsync();
        }

    }
}
