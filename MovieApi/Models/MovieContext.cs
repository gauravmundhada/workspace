using System;
using Microsoft.EntityFrameworkCore;
using MovieApi.ViewModel;
 
namespace MovieApi.Models;
 
    public class MovieContext:DbContext
    {
        public virtual DbSet<Movie> Movies{get;set;}
        public virtual DbSet<Detail> Details{get;set;}
        public virtual DbSet<Movie_VM> Movie_VMs{get;set;}
 
        public MovieContext(){}
        public MovieContext(DbContextOptions<MovieContext>options): base (options)
        {
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=EntDb;trusted_connection=false;Persist Security Info=False;Encrypt=False;");
            }
        }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.Entity<Movie_VM>().HasNoKey();
            }
    }