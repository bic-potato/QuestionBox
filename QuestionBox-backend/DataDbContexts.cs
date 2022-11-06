using Microsoft.EntityFrameworkCore;

namespace QuestionBox_backend
{
    public class DataDbContexts:DbContext
    {
        public DataDbContexts()
        { }     

        public DataDbContexts(DbContextOptions<DataDbContexts> options):base(options)
        { }

        public virtual DbSet<DataModel> DataModel { get; set; } = null!;
    }
}
