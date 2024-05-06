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
            
            CheckName(request.Name);
            CheckDescription(request.Description);
            CheckLogo(request.Logo);

            return (await _gamesDataAccess.Create(request)).ToDto();
        }

        public async Task Update(GameUpdateRequest request)
        {
            var game = await _gamesDataAccess.GetGameById(request.Id);
            if (game is null)
                throw new InvalidDataException("Erreur jeu introuvable");
            
            CheckDescription(request.Description);
            CheckLogo(request.Logo);

            game.Description = request.Description;
            game.Logo = request.Logo;
            await _gamesDataAccess.SaveChanges();
        }
        
        
        public async Task Delete(int id)
        {
            var game = await _gamesDataAccess.GetGameById(id);
            if (game is null)
                throw new InvalidDataException("Erreur jeu introuvable");
            await _gamesDataAccess.Remove(id);
        }
        
        
        
        
        
        
        
        
        
        private void CheckDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) {
                throw new InvalidDataException("Erreur: Description vide");
            }
            
            if (description.Length < 10) {
                throw new InvalidDataException(
                    "Erreur: Description doit être >= à 10 caracteres"
                );
            }
        }
        
        private void CheckLogo(string logo)
        {
            if (string.IsNullOrWhiteSpace(logo)) {
                throw new InvalidDataException("Erreur: Logo vide");
            }
        }

        
        private void CheckName(string name) {
            // TODO: check name duplications

            if (string.IsNullOrWhiteSpace(name)) {
                throw new InvalidDataException("Erreur: Nom vide");
            }
        }
        
    }
}

