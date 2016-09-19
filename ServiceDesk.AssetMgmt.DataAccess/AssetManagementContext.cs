using ServiceDesk.AssetMgmt.Domain;
using System.Data.Entity;

namespace ServiceDesk.AssetMgmt.DataAccess
{
    public class AssetManagementContext : DbContext
    {
        public AssetManagementContext()
            : base("ServiceDeskDb")
        {

        }

        public DbSet<DummyAsset> DummyAssets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("AssetMgmt");
            base.OnModelCreating(modelBuilder);
        }
    }
}
