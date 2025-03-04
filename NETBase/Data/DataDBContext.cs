using Microsoft.EntityFrameworkCore;
using NETBase.Models;

namespace NETBase.Data
{
    public class DataDBContext: DbContext
    {
        public DataDBContext(DbContextOptions options) : base(options)
        { }
        public virtual DbSet<User> User { get; set; }

        public DataDBContext CreateConnection(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataDBContext>();
            optionsBuilder.UseNpgsql(connectionString);
            var context = new DataDBContext(optionsBuilder.Options);
            return context;
        }
    }
}
