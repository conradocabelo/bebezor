using Bebezor.App.Model;
using Bebezor.App.Model.Characters;
using Bebezor.App.Services.CharactersService;
using Microsoft.AspNetCore.Components;

namespace Bebezor.App.Pages.Marvel
{
    public partial class PaginaInicial
    {
        [Inject]
        public ICharacterService CharacterService { get; set; }

        public ResponseApi<Character> Characteres { get; set; }

        protected override async void OnInitialized()
        {
            Characteres = await CharacterService.SearchCharacters();
            StateHasChanged();
        }       
    }
}
