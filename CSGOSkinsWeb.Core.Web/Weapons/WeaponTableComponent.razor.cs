using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Weapons
{
    public partial class WeaponTableComponent : ComponentBase
    {
        [Parameter]
        public List<Weapon> Weapons  { get; set; }

        [Parameter]
        public List<Skin> Skins { get; set; }

        private int WeaponSkinCount(string idString)
        {
            return Skins.Count(x => x.WeaponNavigation?.Idstring == idString);
        }

        private List<Weapon> GetWeaponsWithCategory(int category)
        {
            List<Weapon> weaps = new List<Weapon>();

            foreach (Weapon weap in Weapons)
            {
                if(weap.Category == category)
                    weaps.Add(weap);
            }

            return weaps;
        }
    }
}
