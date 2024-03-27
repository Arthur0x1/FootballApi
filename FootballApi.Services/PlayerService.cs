using FootballApi.Domains.Entities;
using FootballApi.Repositories.Interfaces;
using FootballApi.Services.Interfaces;

namespace FootballApi.Repositories
{
	public class PlayerService : IService<Player>
	{
		private readonly IDao<Player> _playerDao;

        public PlayerService(IDao<Player> playerDao)
        {
			_playerDao = playerDao;
        }

        public async Task Add(Player entity)
		{
			await _playerDao.Add(entity);
		}

		public async Task<Player?> FindById(int id)
		{
			return await _playerDao.FindById(id);
		}

		public async Task<IEnumerable<Player>> GetAll()
		{
			return await _playerDao.GetAll();
		}
	}
}
