using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Skins
{
    public partial class SkinViewComponent : OwningComponentBase
    {
        [Parameter]
        public Skin WeaponSkin { get; set; }


    }
}
