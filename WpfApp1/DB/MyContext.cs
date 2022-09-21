using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DB
{
    public class MyContext : DbContext
    {
        private string cs =
            "Server=192.168.10.160; database=KODIAl_Test; user id = stud; password=stud; connect Timeout = 5; ";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<EntryControl> EntryControls { get; set; }
    }
}
