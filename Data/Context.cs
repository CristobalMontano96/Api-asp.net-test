using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}