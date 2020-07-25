using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CSGOSkinsWeb.Core.Web.Cases
{
    public partial class CaseEditComponent : OwningComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        [Inject]
        public ICaseService CaseService { get; set; }

        [Parameter]
        public WeaponCase WeaponCase { get; set; }



        private async Task DeleteCaseAsync()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
            if (confirmed)
            {
                await CaseService.DeleteCaseAsync(WeaponCase);

                NavigationManager.NavigateTo("/cases");
            }
        }

        private async Task HandleValidSubmitAsync()
        {
            await CaseService.UpdateCaseAsync(WeaponCase);
            base.StateHasChanged();
        }

        private void ReturnToViewPage()
        {
            NavigationManager.NavigateTo($"/cases/{WeaponCase.Idstring}");
        }
    }
}
