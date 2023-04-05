using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BookApp.Authorization.Roles;
using BookApp.Authorization.Users;
using BookApp.MultiTenancy;
using BookApp.Entities;

namespace BookApp.EntityFrameworkCore
{
    public class BookAppDbContext : AbpZeroDbContext<Tenant, Role, User, BookAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BookAppDbContext(DbContextOptions<BookAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<BookInfo> Book { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

    }
}
