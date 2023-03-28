using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BookApp.EntityFrameworkCore
{
    public static class BookAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BookAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BookAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
