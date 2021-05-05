using HospitalAPI.Core.Models;
using HospitalAPI.DataAccess.Data;
using HospitalAPI.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _repo;

        public BranchController(IBranchRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> Getbranch()
        {
            var branches =await _repo.GetBranchesAsync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> Getbranch(int id)
        {
            var branch = await _repo.GetBranchByIdAsync(id);
            return Ok(branch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, Branch branch)
        {
            var updateBranch =await _repo.PutBranchAsync(id, branch);
            return Ok(updateBranch);
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> PostBranch(Branch branch)
        {
            var postBranch =await _repo.PostBranchAsync(branch);
            return Ok(postBranch);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branches =await _repo.DeleteBranchAsync(id);

            return Ok(branches);
        }

    }
}
