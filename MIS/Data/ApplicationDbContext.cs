﻿using Microsoft.EntityFrameworkCore;
using MIS.Domains;

namespace MIS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<Student> Students {  get; set; }

    }

}
