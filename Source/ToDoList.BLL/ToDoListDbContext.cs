using Microsoft.EntityFrameworkCore;

namespace ToDoList.BLL
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) 
            : base(options)
        {

        }

        /// <summary>
        /// A dbset egy ToDoItem table
        /// </summary>
        public DbSet<ToDoItem> ToDoItemData { get; set; }
    }
}
