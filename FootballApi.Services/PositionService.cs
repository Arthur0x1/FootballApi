using FootballApi.Domains.Entities;
using FootballApi.Repositories.Interfaces;
using FootballApi.Services.Interfaces;

namespace FootballApi.Services
{
	public class PositionService : IService<Position>
	{
		private readonly IDao<Position> _positionDao;

        public PositionService(IDao<Position> positionDao)
        {
			_positionDao = positionDao;
        }

        public async Task Add(Position entity)
		{
			await _positionDao.Add(entity);
		}

		public async Task<Position?> FindById(int id)
		{
			return await _positionDao.FindById(id);
		}

		public async Task<IEnumerable<Position>> GetAll()
		{
			return await _positionDao.GetAll();
		}
	}
}
