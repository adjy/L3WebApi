using L3WebApi.Business.Interfaces;
using L3WebApi.Common.DTO;
using L3WebApi.DataAccess.Interfaces;

namespace L3WebApi.Business.Implementations {
    public class GameService : IGameService
    {

        private readonly IGamesDataAccess _gamesDataAccess;

        public GameService(IGamesDataAccess gamesDataAcces)
        {
            _gamesDataAccess = gamesDataAcces;
        }

        public async Task<IEnumerable<GameDto>> GetGames() {
            return (await _gamesDataAccess.GetGames())
                .Select(gameDao => gameDao.ToDto());
        }
        
        public async Task<GameDto?> GetGameById(int id)
        {
            return (await _gamesDataAccess.GetGameById(id))?.ToDto(); // Si c'est null, on va pas appele le ToDto
            
        }
        
        public async Task<IEnumerable<GameDto>> SearchByName(string name)
        {
            return (await _gamesDataAccess.SearchByName(name))
                .Select(gameDao => gameDao.ToDto());
            
        }
        
    }
}

