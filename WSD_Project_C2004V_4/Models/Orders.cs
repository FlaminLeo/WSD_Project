using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSD_Project_C2004V_4.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        public string CustomerName { get; set; }

        public string FoodDescription { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime DeliveryDate { get; set; }

        public TimeSpan DeliveryTime { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public int OrderQuantity { get; set; }
    }
}
