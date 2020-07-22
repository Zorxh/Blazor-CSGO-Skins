using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Skins
{
    public partial class SkinTableComponent : OwningComponentBase
    {
        [Parameter]
        public List<Skin> WeaponSkins  { get; set; }


    }
}
