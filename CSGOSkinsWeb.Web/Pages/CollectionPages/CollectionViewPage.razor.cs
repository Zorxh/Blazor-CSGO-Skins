using System;
using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Core.Web.Skins;

namespace CSGOSkinsWeb.Web.Pages.CollectionPages
{
    public partial class CollectionViewPage : ComponentBase
    {
        [Inject]
        public ICollectionService CollectionService { get; set; }
        [Inject]
        public ISkinService SkinService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private WeaponCollection weaponCollection;
        private List<Skin> weaponSkins;
        private List<Skin> weaponSkinsByCollectionId = new List<Skin>();

        protected override async Task OnInitializedAsync()
        {
            weaponCollection = await CollectionService.GetCollectionByIdStringAsync(Idstring).ConfigureAwait(false);
            weaponSkins = await SkinService.GetSkinsAsync().ConfigureAwait(false);

            foreach (var skin in weaponSkins.Where(skin => skin.Weapcoll == weaponCollection.Id))
            {
                weaponSkinsByCollectionId.Add(skin);
            }

            SortSkinsByRarity();

            if (weaponCollection == null)
            {
                NavigationManager.NavigateTo("/collections");
                return;
            }
        }

        private void SortSkinsByRarity()
        {
            weaponSkinsByCollectionId = weaponSkinsByCollectionId.OrderBy(x => x.Rarity).ToList();
        }

        private void GoToEditPage()
        {
            NavigationManager.NavigateTo($"/collections/edit/{weaponCollection.Idstring}");
        }
    }
}
