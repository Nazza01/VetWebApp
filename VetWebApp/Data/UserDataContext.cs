using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetWebApp.Models;

namespace UserData.Data
{
    public class UserDataContext : DbContext
    {
        public UserDataContext (DbContextOptions<UserDataContext> options)
            : base(options)
        {
        }

        public DbSet<VetWebApp.Models.UserData> UserData { get; set; } = default!;
    }
}
