namespace WPFAppPractice.repository.Interfaces
{
    public interface IKeyRepository<T, K> 
    {
        T GetByID(K key);
    }
}
