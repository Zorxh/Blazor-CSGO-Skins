using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSGOSkinsWeb.Database.Models
{
    public partial class Category
    {
        public Category()
        {
            Weapon = new HashSet<Weapon>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category")]
        [StringLength(255)]
        public string Category1 { get; set; }

        [InverseProperty("CategoryNavigation")]
        public virtual ICollection<Weapon> Weapon { get; set; }
    }
}
