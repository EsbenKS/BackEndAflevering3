
using AfleveringUge8.Models;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace AfleveringUge8.Models
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        { }

        public DbSet<Translation> Translations { get; set; }
    
    }
}