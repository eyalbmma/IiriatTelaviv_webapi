using DomainIriatTelaviv.Entities;
using DomainIriatTelaviv.Storedprocedures.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv
{
    
    public class TelAvivContext : DbContext
    {

        public TelAvivContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<ShufersalYashirCNCOrderResponse>().HasNoKey();

            //builder.Entity<Users>().HasKey();
        }   
        public virtual DbSet<Users>? Users { get; set; }
        public virtual DbSet<TestData>? TestData { get; set; }
        public virtual DbSet<TestTableResponse>? TestTableResponse { get; set; }

       
        
        //DbSet<ShufersalYashirCNCOrderResponse> ShufersalYashirCNCOrders { get; set; }
    }
}
