﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CSGOSkinsWeb.Core.Web.Skins
{
    public partial class SkinEditComponent : OwningComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public Skin WeaponSkin { get; set; }

        private IEnumerable<Weapon> weaponsList;
        private IEnumerable<WeaponCollection> collectionsList;
        private IEnumerable<WeaponCase> casesList;
        private IEnumerable<Rarity> raritiesList;

        private ISkinService skinService;
        private IWeaponService weaponService;
        private ICollectionService collectionService;
        private ICaseService caseService;
        private IRarityService rarityService;

        protected override async Task OnInitializedAsync()
        {
            skinService = (ISkinService) ScopedServices.GetService(typeof(ISkinService));
            weaponService = (IWeaponService) ScopedServices.GetService(typeof(IWeaponService));
            caseService = (ICaseService)ScopedServices.GetService(typeof(ICaseService));
            collectionService = (ICollectionService)ScopedServices.GetService(typeof(ICollectionService));
            rarityService = (IRarityService)ScopedServices.GetService(typeof(IRarityService));

            weaponsList = await weaponService.GetWeaponsAsync();
            collectionsList = await collectionService.GetCollectionsAsync();
            casesList = await caseService.GetCasesAsync();
            raritiesList = await rarityService.GetRaritiesAsync();
        }

        private async Task DeleteSkinAsync()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
            if (confirmed)
            {
                await skinService.DeleteSkinAsync(WeaponSkin);

                NavigationManager.NavigateTo("/");
            }
        }

        private async Task HandleValidSubmitAsync()
        {
            await skinService.UpdateSkinAsync(WeaponSkin);
            base.StateHasChanged();
        }

        private void ReturnToViewPage()
        {
            NavigationManager.NavigateTo($"/skins/{WeaponSkin.Idstring}");
        }
    }
}
