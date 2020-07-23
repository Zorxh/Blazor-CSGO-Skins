using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;

namespace CSGOSkinsWeb.Web.Pages.CollectionPages
{
    public partial class CollectionCreatePage : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private WeaponCollection weaponCollection;

        /*protected override async Task OnInitializedAsync()
        {

        }*/
    }
}
