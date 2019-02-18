using Microsoft.EntityFrameworkCore;
using NetGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Data
{
    public class GramDbcontext : DbContext
    {
        public GramDbcontext
            (DbContextOptions<GramDbcontext> options) :base
            (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gram>().HasData(
                new Gram
                {
                    ID = 1,
                    Title = "LOLOLOL",
                    Name = "Bill",
                    URL = ".png"
                },
                new Gram
                {
                    ID = 2,
                    Title = "This dog!",
                    Name = "Sam",
                    URL = ".png"
                },
                new Gram
                {
                    ID = 3,
                    Title = "This is Seattle",
                    Name = "Joe",
                    URL = ".png"
                },
                 new Gram
                {
                    ID = 4,
                    Title = ":)",
                    Name = "Kat",
                    URL = ".png"
                },
                new Gram
                {
                    ID = 5,
                    Title = "I love this pizza",
                    Name = "Mat",
                    URL = ".png"
                }
                );
        }
        public DbSet<Gram> Gram { get; set; }
    }
}
