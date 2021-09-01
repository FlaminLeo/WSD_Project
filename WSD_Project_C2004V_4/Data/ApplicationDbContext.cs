using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WSD_Project_C2004V_4.Models;

namespace WSD_Project_C2004V_4.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WSD_Project_C2004V_4.Models.Customer> Customer { get; set; }

        public DbSet<WSD_Project_C2004V_4.Models.Order> Order { get; set; }
    }
}
