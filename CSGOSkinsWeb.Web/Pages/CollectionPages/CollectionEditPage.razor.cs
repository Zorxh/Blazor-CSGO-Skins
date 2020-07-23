using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace CSGOSkinsWeb.Web.Pages.CollectionPages
{
    public partial class CollectionEditPage : ComponentBase
    {
        [Inject]
        public ICollectionService CollectionService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private WeaponCollection weaponCollection;

        protected override async Task OnInitializedAsync()
        {
            weaponCollection = await CollectionService.GetCollectionByIdStringAsync(Idstring).ConfigureAwait(false);

            if (weaponCollection == null)
            {
                NavigationManager.NavigateTo("/collections");
                return;
            }
        }
    }
}
