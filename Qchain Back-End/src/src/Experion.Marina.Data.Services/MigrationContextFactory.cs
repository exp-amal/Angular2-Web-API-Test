using System.Data.Entity.Infrastructure;

namespace Experion.Marina.Data.Services
{
    public class MigrationContextFactory : IDbContextFactory<MarinaContext>
    {
        public MarinaContext Create()
        {
            return new MarinaContext(@"Data Source=COMP-1\SQLEXPRESS;Initial Catalog=QChainDB;User Id=sa;Password=root;MultipleActiveResultSets=true");
        }
    }
}