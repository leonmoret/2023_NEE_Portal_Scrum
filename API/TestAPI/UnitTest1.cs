using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace TestAPI
{
    public class UnitTest1
    {
        private SqliteConnection _connection;
        private object _contextOptions;

        [Fact]
        public async void GetPassenger()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<WWWingsContext>()
                .UseSqlServer(_connection)
                .Options;
            // Create the schema and seed some data
            using WWWingsContext context = new WWWingsContext();

            if (context.Database.EnsureCreated())
            {
                EntityCoreApp.Program.Seed(context);
            }

            // Run the test against one instance of the context
            var controller = new FlightsController(context);
            var result = await controller.GetFlightPrice(1);

            Assert.Equal(450, result.Value);
        }
    }
    }
}