using System;
using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Core.Web.Skins;

namespace CSGOSkinsWeb.Web.Pages.SkinPages
{
    public partial class SkinViewPage : ComponentBase
    {
        [Inject]
        public ISkinService SkinService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private Skin weaponSkin;

        protected override async Task OnInitializedAsync()
        {
            weaponSkin = await SkinService.GetSkinByIdStringAsync(Idstring).ConfigureAwait(false);


            if (weaponSkin == null)
            {
                NavigationManager.NavigateTo("/");
                return;
            }
        }

        private void GoToEditPage()
        {
            NavigationManager.NavigateTo($"/skins/edit/{weaponSkin.Idstring}");
        }
    }
}
