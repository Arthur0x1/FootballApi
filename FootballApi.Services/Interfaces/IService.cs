namespace FootballApi.Services.Interfaces
{
	public interface IService<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T?> FindById(int id);
		Task Add(T entity);
	}
}
