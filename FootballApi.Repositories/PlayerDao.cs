using FootballApi.Domains.Data;
using FootballApi.Domains.Entities;
using FootballApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.Repositories
{
	public class PlayerDao : IDao<Player>
	{
		private readonly FootballDbContext _dbContext = new();

		public async Task Add(Player entity)
		{
			_dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Player?> FindById(int id)
		{
			return await _dbContext.Players.FindAsync(id);
		}

		public async Task<IEnumerable<Player>> GetAll()
		{
			return await _dbContext.Players.ToListAsync();
		}
	}
}
