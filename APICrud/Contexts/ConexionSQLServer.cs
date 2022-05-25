using APICrud.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrud.Contexts
{
    public class ConexionSQLServer:DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer>Options) : base(Options)
        {  
        
        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
