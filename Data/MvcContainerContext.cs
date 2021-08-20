using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudContainer.Models;

    public class MvcContainerContext : DbContext
    {
        public MvcContainerContext (DbContextOptions<MvcContainerContext> options)
            : base(options)
        {
        }

        public DbSet<CrudContainer.Models.Container> Container { get; set; }
    }
