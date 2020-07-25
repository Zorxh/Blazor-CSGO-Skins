using System;
using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Core.Web.Inputs;

namespace CSGOSkinsWeb.Web.Pages.SkinPages
{
    public partial class SkinViewPage : ComponentBase
    {
        [Inject]
        public ISkinService SkinService { get; set; }
        [Inject]
        public ISkinPriceService SkinPriceService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Idstring { get; set; }

        private Skin weaponSkin;
        private List<SkinData> skinData = new List<SkinData>(new SkinData[5]);
        private List<SkinData> skinDataStatTrak = new List<SkinData>(new SkinData[5]);
        private List<SkinData> skinDataSouvenir = new List<SkinData>(new SkinData[5]);

        protected override async Task OnInitializedAsync()
        {
            weaponSkin = await SkinService.GetSkinByIdStringAsync(Idstring).ConfigureAwait(false);

            if (weaponSkin.Wearstart <= 0.07 && weaponSkin.Wearend >= 0.00)
            {
                skinData.Insert(0, new SkinData
                {
                    SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New")),
                    Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New")).Result,
                    Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New")).Result
                });

                if (weaponSkin.Hasstattrak)
                {
                    skinDataStatTrak.Insert(0, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New", true, false)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New", true, false)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New", true, false)).Result
                    });
                }

                if (weaponSkin.Hassouvenir)
                {
                    skinDataSouvenir.Insert(0, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New", false, true)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New", false, true)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Factory New", false, true)).Result
                    });
                }
            }

            if (weaponSkin.Wearstart <= 0.15 && weaponSkin.Wearend >= 0.07)
            {
                skinData.Insert(1, new SkinData
                {
                    SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear")),
                    Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear")).Result,
                    Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear")).Result
                });

                if (weaponSkin.Hasstattrak)
                {
                    skinDataStatTrak.Insert(1, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear", true, false)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear", true, false)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear", true, false)).Result
                    });
                }

                if (weaponSkin.Hassouvenir)
                {
                    skinDataSouvenir.Insert(1, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear", false, true)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear", false, true)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Minimal Wear", false, true)).Result
                    });
                }
            }
            if(weaponSkin.Wearstart <= 0.38 && weaponSkin.Wearend >= 0.15)
            {
                skinData.Insert(2, new SkinData
                {
                    SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested")),
                    Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested")).Result,
                    Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested")).Result
                });

                if (weaponSkin.Hasstattrak)
                {
                    skinDataStatTrak.Insert(2, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested", true, false)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested", true, false)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested", true, false)).Result
                    });
                }

                if (weaponSkin.Hassouvenir)
                {
                    skinDataSouvenir.Insert(2, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested", false, true)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested", false, true)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Field-Tested", false, true)).Result
                    });
                }
            }
            if (weaponSkin.Wearstart <= 0.45 && weaponSkin.Wearend >= 0.38)
            {
                skinData.Insert(3, new SkinData
                {
                    SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn")),
                    Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn")).Result,
                    Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn")).Result
                });

                if (weaponSkin.Hasstattrak)
                {
                    skinDataStatTrak.Insert(3, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn", true, false)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn", true, false)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn", true, false)).Result
                    });
                }

                if (weaponSkin.Hassouvenir)
                {
                    skinDataSouvenir.Insert(3, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn", false, true)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn", false, true)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Well-Worn", false, true)).Result
                    });
                }
            }

            if (weaponSkin.Wearend >= 0.45)
            {
                skinData.Insert(4, new SkinData
                {
                    SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred")),
                    Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred")).Result,
                    Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred")).Result
                });

                if (weaponSkin.Hasstattrak)
                {
                    skinDataStatTrak.Insert(4, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred", true, false)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred", true, false)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred", true, false)).Result
                    });
                }

                if (weaponSkin.Hassouvenir)
                {
                    skinDataSouvenir.Insert(4, new SkinData
                    {
                        SteamFormatHash = SkinPriceService.ConvertToHashKey(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred", false, true)),
                        Price = SetSkinPrice(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred", false, true)).Result,
                        Volume = SetSkinVolume(ConvertToSteamFormat(weaponSkin.WeaponNavigation?.Weapname, weaponSkin.Skinname, "Battle-Scarred", false, true)).Result
                    });
                }
            }

            if (weaponSkin == null)
            {
                NavigationManager.NavigateTo("/");
                return;
            }
        }

        private string ConvertToSteamFormat(string weaponName, string skinName, string condition, bool isStatTrak = false, bool isSouvenir = false)
        {
            if (!isStatTrak && !isSouvenir)
                return $"{weaponName} | {skinName} ({condition})";
            if(isStatTrak)
                return $"StatTrak™ {weaponName} | {skinName} ({condition})";
            if(isSouvenir)
                return $"Souvenir {weaponName} | {skinName} ({condition})";

            return "Wrong input";
        }

        private async Task<string> SetSkinPrice(string steamName)
        {
            return await SkinPriceService.RetrieveSkinPrice(steamName).ConfigureAwait(false);
        }

        private async Task<string> SetSkinVolume(string steamName)
        {
            return await SkinPriceService.RetrieveSkinVolume(steamName).ConfigureAwait(false);
        }

        private void GoToEditPage()
        {
            NavigationManager.NavigateTo($"/skins/edit/{weaponSkin.Idstring}");
        }
    }
}
