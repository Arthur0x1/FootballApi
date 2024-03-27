using FootballApi.Domains.Data;
using FootballApi.Domains.Entities;
using FootballApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.Repositories
{
	public class PositionDao : IDao<Position>
	{
		private readonly FootballDbContext _dbContext = new();

		public async Task Add(Position entity)
		{
			_dbContext.Entry(entity).State = EntityState.Added;
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Position?> FindById(int id)
		{
			return await _dbContext.Positions.FindAsync(id);
		}

		public async Task<IEnumerable<Position>> GetAll()
		{
			return await _dbContext.Positions.ToListAsync();
		}
	}
}
