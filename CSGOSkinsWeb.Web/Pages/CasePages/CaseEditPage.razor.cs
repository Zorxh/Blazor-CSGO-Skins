using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace CSGOSkinsWeb.Web.Pages.CasePages
{
    public partial class CaseEditPage : ComponentBase
    {
        [Inject]
        public ICaseService CaseService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private WeaponCase weaponCase;

        protected override async Task OnInitializedAsync()
        {
            weaponCase = await CaseService.GetCaseByIdStringAsync(Idstring).ConfigureAwait(false);

            if (weaponCase == null)
            {
                NavigationManager.NavigateTo("/cases");
                return;
            }
        }
    }
}
