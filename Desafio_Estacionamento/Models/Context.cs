using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Estacionamento.Models
{
    public class Context: DbContext
    {
        public DbSet<Estacionamento> Estacionamentos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
