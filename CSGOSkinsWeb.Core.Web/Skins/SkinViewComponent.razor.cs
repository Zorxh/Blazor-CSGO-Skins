using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlazorStrap;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Skins
{
    public partial class SkinViewComponent : OwningComponentBase
    {
        [Parameter]
        public Skin WeaponSkin { get; set; }

        private IEnumerable<Weapon> weaponsList;
        private IEnumerable<WeaponCollection> collectionsList;
        private IEnumerable<WeaponCase> casesList;
        private IEnumerable<Rarity> raritiesList;

        private IWeaponService weaponService;
        private ICollectionService collectionService;
        private ICaseService caseService;
        private IRarityService rarityService;
        private IBootstrapCss bootstrapCss;

        protected override async Task OnInitializedAsync()
        {
            weaponService = (IWeaponService)ScopedServices.GetService(typeof(IWeaponService));
            caseService = (ICaseService)ScopedServices.GetService(typeof(ICaseService));
            collectionService = (ICollectionService)ScopedServices.GetService(typeof(ICollectionService));
            rarityService = (IRarityService)ScopedServices.GetService(typeof(IRarityService));
            bootstrapCss = (IBootstrapCss) ScopedServices.GetService(typeof(IBootstrapCss));

            weaponsList = await weaponService.GetWeaponsAsync();
            collectionsList = await collectionService.GetCollectionsAsync();
            casesList = await caseService.GetCasesAsync();
            raritiesList = await rarityService.GetRaritiesAsync();
        }

        private Weapon GetWeapon(int weaponId)
        {
            if(weaponsList != null)
                return weaponsList.FirstOrDefault(x => x.Id == weaponId);
            else
                return new Weapon{Id = weaponId, Weapname = "Bad Weapon"};
        }

        private string FloatRight(double floatStart)
        {
            var returnVal = floatStart;

            if (floatStart > 0)
                returnVal -= 0.00;

            return ((returnVal) * 100) + "%";
        }

        private string FloatLeft(double floatEnd)
        {
            var returnVal = floatEnd;

            if (floatEnd > 1)
                returnVal -= 0.03;

            return ((1 - returnVal) * 100) + "%";
        }

        private string AvailableFloat(double floatEnd, double floatStart)
        {
            double floatVal = ((floatEnd - floatStart) * 100);

            if(floatStart == 0 && floatEnd == 1)
                return (floatVal-0.25) + "%; border-radius: 5px 5px 5px 5px;";

            if (floatStart <= 0)
                return floatVal + "%; border-radius: 5px 0 0 5px;";

            else if (floatEnd >= 1)
                return floatVal + "%; border-radius: 0 5px 5px 0;";

            else
                return floatVal + "%";
        }
    }
}
