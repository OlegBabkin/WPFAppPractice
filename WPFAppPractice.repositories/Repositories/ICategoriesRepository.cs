using WPFAppPractice.domain;
using WPFAppPractice.repository.Interfaces;

namespace WPFAppPractice.repository.Repositories
{
    public interface ICategoriesRepository : IRepository<Category>, IKeyRepository<Category, int>
    {
    }
}
