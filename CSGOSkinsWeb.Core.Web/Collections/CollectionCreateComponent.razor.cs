using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Collections
{
    public partial class CollectionCreateComponent : OwningComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public WeaponCollection weaponCollection = new WeaponCollection();

        private ICollectionService CollectionService;

        protected override void OnInitialized()
        {
            CollectionService = (ICollectionService)ScopedServices.GetService(typeof(ICollectionService));
        }

        private async Task HandleValidSubmitAsync()
        {
            await CollectionService.CreateCollectionAsync(weaponCollection);

            NavigationManager.NavigateTo($"/collections");
        }

        private void ReturnToTablePage()
        {
            NavigationManager.NavigateTo($"/collections");
        }
    }
}
