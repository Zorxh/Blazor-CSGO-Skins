using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Cases
{
    public partial class CaseViewComponent : OwningComponentBase
    {
        [Parameter] 
        public WeaponCase WeaponCase { get; set; }


        [Parameter]
        public string Price { get; set; }

        [Parameter]
        public string Volume { get; set; }

        private ICasePriceService casePriceService;

        protected override void OnInitialized()
        {
            casePriceService = (ICasePriceService) ScopedServices.GetService(typeof(ICasePriceService));
        }
    }
}
