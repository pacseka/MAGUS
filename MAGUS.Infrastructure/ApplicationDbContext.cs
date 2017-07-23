using MAGUS.Infrastructure;

namespace MAGUS.Infrastructure
{

    public class ApplicationDbContext : MongoDbContext
    {
        
        public ApplicationDbContext(): base()
        {
           
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}