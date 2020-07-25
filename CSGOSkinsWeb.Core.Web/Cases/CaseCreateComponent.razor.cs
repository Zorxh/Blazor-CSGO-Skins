using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Cases
{
    public partial class CaseCreateComponent : OwningComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ICaseService CaseService { get; set; }

        public WeaponCase weaponCase = new WeaponCase();

        private async Task HandleValidSubmitAsync()
        {
            await CaseService.CreateCaseAsync(weaponCase);

            NavigationManager.NavigateTo($"/cases");
        }

        private void ReturnToTablePage()
        {
            NavigationManager.NavigateTo($"/cases");
        }
    }
}
