using System.Collections.Generic;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Cases
{
    public partial class CaseTableComponent : OwningComponentBase
    {
        [Parameter]
        public List<WeaponCase> Cases  { get; set; }
    }
}
