using System.Data.Entity;
using WPFAppPractice.domain;

namespace WpfApplication2.Connection
{
    public partial class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("name=ProductDBEntitiesConn") { }
        public ProductDBContext(string connectionName) : base("name="+connectionName) { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
