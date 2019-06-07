using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PFSoftware.Business
{
    public class AuditableDbContext : DbContext
    {
        public AuditableDbContext();
        public AuditableDbContext(DbCompiledModel model);
        public AuditableDbContext(string nameOrConnectionString);
        public AuditableDbContext(DbConnection existingConnection, bool contextOwnsConnection);
        public AuditableDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext);
        public AuditableDbContext(string nameOrConnectionString, DbCompiledModel model);
        public AuditableDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection);

        public override int SaveChanges();
        [AsyncStateMachine(typeof(< SaveChangesAsync > d__9))]
        public override Task<int> SaveChangesAsync();
        protected override void Dispose(bool disposing);
    }
}
