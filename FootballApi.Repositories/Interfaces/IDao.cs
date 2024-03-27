namespace FootballApi.Repositories.Interfaces
{
	public interface IDao<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T?> FindById(int id);
		Task Add(T entity);
	}
}
