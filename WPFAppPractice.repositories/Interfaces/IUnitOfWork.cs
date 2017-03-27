using WPFAppPractice.domain;
using WPFAppPractice.repository.Repositories;

namespace WPFAppPractice.repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductsRepository Products { get; }
        ICategoriesRepository Categories { get; }

        void Save();
    }
}
