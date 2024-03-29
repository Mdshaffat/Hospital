﻿using HospitalAPI.Core.Models;
using HospitalAPI.Core.Specification;
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
        private readonly IGenericRepository<Branch> _branchrepo;

        public BranchController(IBranchRepository repo, IGenericRepository<Branch> branchrepo)
        {
            _repo = repo;
            _branchrepo = branchrepo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> Getbranch(string sort,string district, bool? isactive, string search)
        {
            var spec = new BranchWithOrderBySpecification(sort, district, isactive,search);
            var branches =await _branchrepo.ListAsyncWithSpec(spec);


            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> Getbranch(int id)
        {
            var branch = await _branchrepo.GetByIdAsync(id);
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
