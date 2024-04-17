using L3WebApi.Business.Interfaces;
using L3WebApi.Common.DTO;
using L3WebApi.DataAccess.Interfaces;
using L3WebApi.Common.Requests;

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

        public async Task<GameDto> Create(GameCreationRequest request) {
            if (request == null) {
                throw new InvalidDataException("Erreur inconnue");
            }

            // TODO: check name duplications

            if (string.IsNullOrWhiteSpace(request.Name)) {
                throw new InvalidDataException("Erreur: Nom vide");
            }

            if (string.IsNullOrWhiteSpace(request.Description)) {
                throw new InvalidDataException("Erreur: Description vide");
            }

            if (request.Description.Length < 10) {
                throw new InvalidDataException(
                    "Erreur: Description doit être >= à 10 caracteres"
                );
            }

            if (string.IsNullOrWhiteSpace(request.Logo)) {
                throw new InvalidDataException("Erreur: Logo vide");
            }

            return (await _gamesDataAccess.Create(request)).ToDto();
        }
        
    }
}

