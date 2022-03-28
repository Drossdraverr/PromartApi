using Microsoft.EntityFrameworkCore;
using PromartApi.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromartApi.Utilidades
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
