using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSD_Project_C2004V_4.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }
    }
}
