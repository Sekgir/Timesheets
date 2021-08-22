using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.DAL.Models;

namespace Timesheets
{
    public class TimesheetsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<InvoiceTask> InvoiceTask { get; set; }
        public DbSet<TaskEmployee> TaskEmployee { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=GeekBrains;Username=postgres;Password=qwe123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.IdCustomer);
            modelBuilder.Entity<Customer>()
                .HasOne(p => p.Person)
                .WithOne(c => c.Customer)
                .HasForeignKey<Customer>(c => c.IdPerson);
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Person)
                .WithOne(e => e.Employee)
                .HasForeignKey<Employee>(e => e.IdPerson);
            modelBuilder.Entity<Invoice>()
                .HasOne(c => c.Contract)
                .WithMany(i => i.Invoices)
                .HasForeignKey(c => c.IdContract);
            modelBuilder.Entity<InvoiceTask>()
                .HasOne(i => i.Invoice)
                .WithMany(i => i.InvoiceTasks)
                .HasForeignKey(i => i.IdInvoice);
            modelBuilder.Entity<InvoiceTask>()
                .HasOne(t => t.Task)
                .WithMany(i => i.InvoiceTasks)
                .HasForeignKey(t => t.IdTask);
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Contract)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.IdContract);
            modelBuilder.Entity<TaskEmployee>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.TaskEmployees)
                .HasForeignKey(t => t.IdEmployee);
            modelBuilder.Entity<TaskEmployee>()
                .HasOne(t => t.Task)
                .WithMany(e => e.TaskEmployees)
                .HasForeignKey(t => t.IdTask);
        }

    }
}
