using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            IdentityRole<int>[] roles = new IdentityRole<int>[]
            {
                new IdentityRole<int>("Customer"),
                new IdentityRole<int>("Admin"),
                new IdentityRole<int>("SysAdmin")
            };
        }
    }
}
