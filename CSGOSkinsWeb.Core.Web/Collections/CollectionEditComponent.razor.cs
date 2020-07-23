using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CSGOSkinsWeb.Core.Web.Collections
{
    public partial class CollectionEditComponent : OwningComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public WeaponCollection WeaponCollection { get; set; }

        private ICollectionService collectionService;

        protected override void OnInitialized()
        {
            collectionService = (ICollectionService)ScopedServices.GetService(typeof(ICollectionService));
        }

        private async Task DeleteCollectionAsync()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
            if (confirmed)
            {
                await collectionService.DeleteCollectionAsync(WeaponCollection);

                NavigationManager.NavigateTo("/cases");
            }
        }

        private async Task HandleValidSubmitAsync()
        {
            await collectionService.UpdateCollectionAsync(WeaponCollection);
            base.StateHasChanged();
        }

        private void ReturnToViewPage()
        {
            NavigationManager.NavigateTo($"/collections/{WeaponCollection.Idstring}");
        }
    }
}
