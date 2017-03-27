using WPFAppPractice.domain;
using WPFAppPractice.repository.Interfaces;

namespace WPFAppPractice.repository.Repositories
{
    public interface IProductsRepository : IRepository<Product>, IKeyRepository<Product, int>
    {
    }
}
