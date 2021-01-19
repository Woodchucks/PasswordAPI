using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordAPI.Models
{
    public class PasswordDetailsContext : DbContext
    {
        public PasswordDetailsContext(DbContextOptions<PasswordDetailsContext> options) : base(options)
        {

        }
        public DbSet<PasswordDetails> PasswordsDetails { get; set; }
    }
}
