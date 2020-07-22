using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSGOSkinsWeb.Database.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            Skin = new HashSet<Skin>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("weapname")]
        [StringLength(255)]
        public string Weapname { get; set; }
        [Column("category")]
        public int? Category { get; set; }
        [Column("idstring")]
        [StringLength(255)]
        public string Idstring { get; set; }
        [Column("imgsrc")]
        [StringLength(1000)]
        public string Imgsrc { get; set; }

        [ForeignKey(nameof(Category))]
        [InverseProperty("Weapon")]
        public virtual Category CategoryNavigation { get; set; }
        [InverseProperty("WeaponNavigation")]
        public virtual ICollection<Skin> Skin { get; set; }
    }
}
