
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthDeptApp.Models
{
    public class Establishment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Score { get; set; }
        public bool HasLiquorLicense { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
            