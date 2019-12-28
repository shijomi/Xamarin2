using System.Data.Entity;

namespace ApiXamarin.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<ApiXamarin.Models.Work> Works { get; set; }
    }
}