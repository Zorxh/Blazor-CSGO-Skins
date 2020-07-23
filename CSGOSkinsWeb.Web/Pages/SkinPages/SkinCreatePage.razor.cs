using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;

namespace CSGOSkinsWeb.Web.Pages.SkinPages
{
    public partial class SkinCreatePage : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private Skin skin;

        /*protected override async Task OnInitializedAsync()
        {

        }*/
    }
}
