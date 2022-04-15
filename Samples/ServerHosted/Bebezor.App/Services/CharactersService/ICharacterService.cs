using Bebezor.App.Model;
using Bebezor.App.Model.Characters;

namespace Bebezor.App.Services.CharactersService
{
    public interface ICharacterService
    {
        Task<ResponseApi<Character>> SearchCharacters();
    }
}