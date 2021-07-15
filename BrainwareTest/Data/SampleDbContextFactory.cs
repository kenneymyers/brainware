using BrainWare.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;


namespace BrainwareTest.Data
{
    public class SampleDbContextFactory : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<SqlLiteDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<SqlLiteDbContext>()
                .UseSqlite(_connection).Options;
        }

        public SqlLiteDbContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using (var context = new SqlLiteDbContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new SqlLiteDbContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
