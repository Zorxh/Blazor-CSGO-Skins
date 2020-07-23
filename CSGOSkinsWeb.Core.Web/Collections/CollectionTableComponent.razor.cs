using System.Collections.Generic;
using System.Collections.ObjectModel;
using CSGOSkinsWeb.Database.Models;
using Microsoft.AspNetCore.Components;

namespace CSGOSkinsWeb.Core.Web.Collections
{
    public partial class CollectionTableComponent : OwningComponentBase
    {
        [Parameter]
        public List<WeaponCollection> Collections  { get; set; }
    }
}
