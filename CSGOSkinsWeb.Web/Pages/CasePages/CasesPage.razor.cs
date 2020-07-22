using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;

namespace CSGOSkinsWeb.Web.Pages.CasePages
{
    public partial class CasesPage : ComponentBase
    {
        [Inject]
        public ICaseService CaseService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private List<WeaponCase> cases;

        protected override async Task OnInitializedAsync()
        {
            cases = await CaseService.GetCasesAsync().ConfigureAwait(false);
            cases.Reverse();
        }

        private void GoToCreatePage()
        {
            NavigationManager.NavigateTo("/cases/create");
        }
    }
}
