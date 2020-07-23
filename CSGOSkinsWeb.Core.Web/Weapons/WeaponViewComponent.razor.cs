using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Weapons
{
    public partial class WeaponViewComponent : OwningComponentBase
    {
        [Parameter]
        public Weapon Weapon { get; set; }

    }
}
