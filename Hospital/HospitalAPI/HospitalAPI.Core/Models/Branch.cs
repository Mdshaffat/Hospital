using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Core.Models
{
    public class Branch : ModelBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Upazila { get; set; }
        public string District { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
