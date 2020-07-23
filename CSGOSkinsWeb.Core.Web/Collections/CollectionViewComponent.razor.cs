using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Collections
{
    public partial class CollectionViewComponent : OwningComponentBase
    {
        [Parameter]
        public WeaponCollection WeaponCollection { get; set; }

    }
}
