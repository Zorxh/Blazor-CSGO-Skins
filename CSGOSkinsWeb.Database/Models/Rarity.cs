using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSGOSkinsWeb.Database.Models
{
    public partial class Rarity
    {
        public Rarity()
        {
            Skin = new HashSet<Skin>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("rarityname")]
        [StringLength(100)]
        public string Rarityname { get; set; }

        [InverseProperty("RarityNavigation")]
        public virtual ICollection<Skin> Skin { get; set; }
    }
}
