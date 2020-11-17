using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Sample.Common.Models;

namespace Sample.DAL
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }
        
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Order> MedicineOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("tableMedicines_PK");

                entity.ToTable("tableMedicines");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("lnkMedicineOrder_PK");

                entity.ToTable("lnkMedicineOrder");

                entity.Property(e => e.OrderCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderedBy)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne<Medicine>()
                    .WithMany()
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("lnkMedicineOrder_tableMedicines_FK");
            });

            //// Here we’ll do table and class mapping using fluent-api}
            //modelBuilder.Entity<SampleTable>(entity => {

            //    entity.ToTable("SampleTable", "dbo");

            //    entity.HasKey(s => s.Id)
            //            .HasName("SampleTable_PK");

            //    //entity.HasData(
            //    //        new SampleTable { Id = 2,  Name = "Suresh" },
            //    //        new SampleTable { Id = 3, Name = "Ramesh" },
            //    //        new SampleTable { Id = 4, Name = "Akhil" },
            //    //        new SampleTable { Id = 5, Name = "Arun" },
            //    //        new SampleTable { Id = 6, Name = "Raj" }
            //    //    );

            //    entity
            //    .Property(s => s.Id)
            //    .HasColumnName("Id")
            //    .ValueGeneratedOnAdd();

            //    entity
            //    .Property(s => s.Name)
            //    .HasColumnName("Name")
            //    .IsRequired();

            //});
        }

    }
}
