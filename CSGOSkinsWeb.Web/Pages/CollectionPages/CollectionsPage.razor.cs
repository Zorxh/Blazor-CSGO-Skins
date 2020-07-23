using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;

namespace CSGOSkinsWeb.Web.Pages.CollectionPages
{
    public partial class CollectionsPage : ComponentBase
    {
        [Inject]
        public ICollectionService CollectionService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private List<WeaponCollection> collections;

        protected override async Task OnInitializedAsync()
        {
            collections = await CollectionService.GetCollectionsAsync().ConfigureAwait(false);
            collections.Reverse();
        }

        private void GoToCreatePage()
        {
            NavigationManager.NavigateTo("/collections/create");
        }
    }
}
