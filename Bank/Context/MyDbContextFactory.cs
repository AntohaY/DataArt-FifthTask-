
namespace RevercePOCO
{

    public partial class MyDbContextFactory : System.Data.Entity.Infrastructure.IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create()
        {
            return new MyDbContext();
        }
    }
}

