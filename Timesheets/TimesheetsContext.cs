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
        public DbSet<InvoiceTaskEmpl> InvoiceTaskEmpl { get; set; }
        public DbSet<TaskEmployee> TaskEmployee { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=GeekBrains;Username=postgres;Password=qwe123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(p => p.Person)
                .WithOne(c => c.Customer)
                .HasForeignKey<Customer>(c => c.IdPerson);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Person)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(e => e.IdPerson);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.IdCustomer);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Contract)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.IdContract);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Contract)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.IdContract);

            modelBuilder.Entity<InvoiceTask>()
                .HasOne(i => i.Invoice)
                .WithMany(i => i.InvoiceTasks)
                .HasForeignKey(i => i.IdInvoice);

            modelBuilder.Entity<InvoiceTask>()
                .HasOne(i => i.Task)
                .WithOne(t => t.InvoiceTask)
                .HasForeignKey<InvoiceTask>(i => i.IdTask);

            modelBuilder.Entity<TaskEmployee>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.TaskEmployees)
                .HasForeignKey(t => t.IdEmployee);

            modelBuilder.Entity<TaskEmployee>()
                .HasOne(t => t.Task)
                .WithMany(t => t.TaskEmployees)
                .HasForeignKey(t => t.IdTask);

            modelBuilder.Entity<InvoiceTaskEmpl>()
                .HasOne(i => i.Invoice)
                .WithMany(i => i.InvoiceTaskEmpls)
                .HasForeignKey(i => i.IdInvoice);

            modelBuilder.Entity<InvoiceTaskEmpl>()
                .HasOne(i => i.TaskEmployee)
                .WithOne(t => t.InvoiceTaskEmpl)
                .HasForeignKey<InvoiceTaskEmpl>(i => i.IdTaskEmployee);
        }

    }
}
