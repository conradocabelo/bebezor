using Bebezor.App.Model;
using Bebezor.App.Model.Characters;
using Bebezor.Sample.Services.BaseService;

namespace Bebezor.App.Services.CharactersService
{
    public class CharacterService : BaseService, ICharacterService
    {
        public CharacterService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ResponseApi<Character>> SearchCharacters() =>
            await GetAsync<ResponseApi<Character>>("characters");
    }
}
