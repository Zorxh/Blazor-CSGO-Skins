using System;
using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Core.Web.Skins;

namespace CSGOSkinsWeb.Web.Pages.WeaponPages
{
    public partial class WeaponViewPage : ComponentBase
    {
        [Inject]
        public IWeaponService WeaponService { get; set; }
        [Inject]
        public ISkinService SkinService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private Weapon weapon;
        private List<Skin> weaponSkins;
        private List<Skin> weaponSkinsByWeaponId = new List<Skin>();

        protected override async Task OnInitializedAsync()
        {
            weapon = await WeaponService.GetWeaponByIdStringAsync(Idstring).ConfigureAwait(false);
            weaponSkins = await SkinService.GetSkinsAsync().ConfigureAwait(false);

            SortSkinList();

            if (weapon == null)
            {
                NavigationManager.NavigateTo("/weapons");
                return;
            }
        }

        private void SortSkinList()
        {
            foreach (var skin in weaponSkins.Where(skin => skin.Weapon == weapon.Id))
            {
                weaponSkinsByWeaponId.Add(skin);
            }
        }
    }
}
