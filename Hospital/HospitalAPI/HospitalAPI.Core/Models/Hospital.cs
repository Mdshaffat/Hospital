using System;

namespace HospitalAPI.Core.Models
{
    public class Hospital : ModelBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Upazila { get; set; }
        public string District { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}
