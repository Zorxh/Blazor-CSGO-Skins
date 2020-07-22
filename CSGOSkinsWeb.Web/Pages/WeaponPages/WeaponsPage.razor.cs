using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;

namespace CSGOSkinsWeb.Web.Pages.WeaponPages
{
    public partial class WeaponsPage : ComponentBase
    {
        [Inject]
        public IWeaponService WeaponService { get; set; }
        [Inject]
        public ISkinService SkinService { get; set; }

        public List<Skin> weaponSkins;

        private List<Database.Models.Weapon> weapons;


        protected override async Task OnInitializedAsync()
        {
            weapons = await WeaponService.GetWeaponsAsync().ConfigureAwait(false);

            weaponSkins = await SkinService.GetSkinsAsync().ConfigureAwait(false);
        }
    }
}
