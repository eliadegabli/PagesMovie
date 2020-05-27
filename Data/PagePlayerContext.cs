using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagesMovie.Models;

namespace PagesMovie.Data
{
    public class PagePlayerContext : DbContext
    {
        public PagePlayerContext (DbContextOptions<PagePlayerContext> options)
            : base(options)
        {
        }

        public DbSet<PagesMovie.Models.Player> Player { get; set; }
    }
}
