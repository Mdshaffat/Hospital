using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Core.Models
{
   public class ModelBase
    {
        [Key]
        public int Id { get; set; }
    }
}
