using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Harboard_Back.Domain.Entities;

namespace Harboard_Back.Infra.Database
{
    public class PostgreSQLDbContext : DbContext
    {

        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> options) : base(options)
        {

        }

        public DbSet<Conteiner> conteiner { get; set; }

    }
}
