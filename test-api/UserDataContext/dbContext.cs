using Microsoft.EntityFrameworkCore;
using test_api.Models;

namespace test_api.UserDataContext
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions option):base(option)
        {

        }

        public DbSet<MyListGetModel> mylines { get; set; }
    }
}
