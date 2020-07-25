using System;
using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Core.Web.Skins;

namespace CSGOSkinsWeb.Web.Pages.CasePages
{
    public partial class CaseViewPage : ComponentBase
    {
        [Inject]
        public ICaseService CaseService { get; set; }
        [Inject]
        public ISkinService SkinService { get; set; }
        [Inject]
        public ICasePriceService CasePriceService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private string casePrice = "", caseVolume = "";
        private WeaponCase weaponCase;
        private List<Skin> weaponSkins;
        private List<Skin> weaponSkinsByCaseId = new List<Skin>();

        protected override async Task OnInitializedAsync()
        {
            weaponCase = await CaseService.GetCaseByIdStringAsync(Idstring).ConfigureAwait(false);
            weaponSkins = await SkinService.GetSkinsAsync().ConfigureAwait(false);

            foreach (var skin in weaponSkins.Where(skin => skin.Weapcase == weaponCase.Id))
            {
                weaponSkinsByCaseId.Add(skin);
            }

            await SetCasePrice(weaponCase.Casename).ConfigureAwait(false);
            await SetCaseVolume(weaponCase.Casename).ConfigureAwait(false);

            SortSkinsByRarity();

            if (weaponCase == null)
            {
                NavigationManager.NavigateTo("/cases");
                return;
            }
        }

        private async Task SetCasePrice(string caseName)
        {
            casePrice = await CasePriceService.RetrieveCasePrice(caseName).ConfigureAwait(false);
        }

        private async Task SetCaseVolume(string caseName)
        {
            caseVolume = await CasePriceService.RetrieveCaseVolume(caseName).ConfigureAwait(false);
        }

        private void SortSkinsByRarity()
        {
            weaponSkinsByCaseId = weaponSkinsByCaseId.OrderBy(x => x.Rarity).ToList();
        }

        private void GoToEditPage()
        {
            NavigationManager.NavigateTo($"/cases/edit/{weaponCase.Idstring}");
        }
    }
}
