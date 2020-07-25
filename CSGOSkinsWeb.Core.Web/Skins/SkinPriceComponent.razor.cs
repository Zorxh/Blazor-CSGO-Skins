using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;
using BlazorStrap;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Core.Web.Inputs;

namespace CSGOSkinsWeb.Core.Web.Skins
{
    public partial class SkinPriceComponent : ComponentBase
    {
        [Parameter]
        public Skin WeaponSkin  { get; set; }

        [Parameter]
        public List<SkinData> SkinData { get; set; }

        [Parameter] 
        public List<SkinData> SkinDataStatTrak { get; set; } = null;

        [Parameter] 
        public List<SkinData> SkinDataSouvenir { get; set; } = null;

        private readonly string fn = "Factory New";
        private readonly string mw = "Minimal Wear";
        private readonly string ft = "Field-Tested";
        private readonly string ww = "Well-Worn";
        private readonly string bs = "Battle-Scarred";
        private readonly string st = "StatTrak™";
        private readonly string sv = "Souvenir™";

        protected override void OnInitialized()
        {
            
        }

        
    }
}
