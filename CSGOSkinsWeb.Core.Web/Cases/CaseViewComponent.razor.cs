using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Cases
{
    public partial class CaseViewComponent : OwningComponentBase
    {
        [Parameter]
        public WeaponCase WeaponCase { get; set; }


    }
}
