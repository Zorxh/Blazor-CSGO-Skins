using System.Collections.Generic;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Skins
{
    public partial class SkinCreateComponent : OwningComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Skin WeaponSkin = new Skin();

        private IEnumerable<Weapon> weaponsList;
        private IEnumerable<WeaponCollection> collectionsList;
        private IEnumerable<WeaponCase> casesList;
        private IEnumerable<Rarity> raritiesList;

        private IWeaponService weaponService;
        private ICollectionService collectionService;
        private ICaseService caseService;
        private IRarityService rarityService;
        private ISkinService skinService;

        protected override async Task OnInitializedAsync()
        {
            skinService = (ISkinService)ScopedServices.GetService(typeof(ISkinService));
            weaponService = (IWeaponService)ScopedServices.GetService(typeof(IWeaponService));
            caseService = (ICaseService)ScopedServices.GetService(typeof(ICaseService));
            collectionService = (ICollectionService)ScopedServices.GetService(typeof(ICollectionService));
            rarityService = (IRarityService)ScopedServices.GetService(typeof(IRarityService));

            weaponsList = await weaponService.GetWeaponsAsync();
            collectionsList = await collectionService.GetCollectionsAsync();
            casesList = await caseService.GetCasesAsync();
            raritiesList = await rarityService.GetRaritiesAsync();
        }

        private async Task HandleValidSubmitAsync()
        {
            await skinService.CreateSkinAsync(WeaponSkin);

            NavigationManager.NavigateTo($"/skins/{WeaponSkin.Idstring}");
        }

        private void ReturnToTablePage()
        {
            NavigationManager.NavigateTo($"/");
        }
    }
}
