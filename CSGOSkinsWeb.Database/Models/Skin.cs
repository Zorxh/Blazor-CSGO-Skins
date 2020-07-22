using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSGOSkinsWeb.Database.Models
{
    public partial class Skin
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("skinname")]
        [StringLength(1000)]
        public string Skinname { get; set; }
        [Column("weapon")]
        public int? Weapon { get; set; }
        [Column("rarity")]
        public int? Rarity { get; set; }
        [Column("weapcase")]
        public int? Weapcase { get; set; }
        [Column("weapcoll")]
        public int? Weapcoll { get; set; }
        [Column("hasstattrak")]
        public bool Hasstattrak { get; set; }
        [Column("hassouvenir")]
        public bool Hassouvenir { get; set; }
        [Column("haspattern")]
        public bool Haspattern { get; set; }
        [Column("wearstart")]
        public double? Wearstart { get; set; }
        [Column("wearend")]
        public double? Wearend { get; set; }
        [Column("skindescription")]
        public string Skindescription { get; set; }
        [Column("idstring")]
        [StringLength(255)]
        public string Idstring { get; set; }
        [Column("imgsrc")]
        [StringLength(1000)]
        public string Imgsrc { get; set; }

        [ForeignKey(nameof(Rarity))]
        [InverseProperty("Skin")]
        public virtual Rarity RarityNavigation { get; set; }
        [ForeignKey(nameof(Weapcase))]
        [InverseProperty(nameof(WeaponCase.Skin))]
        public virtual WeaponCase WeapcaseNavigation { get; set; }
        [ForeignKey(nameof(Weapcoll))]
        [InverseProperty(nameof(WeaponCollection.Skin))]
        public virtual WeaponCollection WeapcollNavigation { get; set; }
        [ForeignKey(nameof(Weapon))]
        [InverseProperty("Skin")]
        public virtual Weapon WeaponNavigation { get; set; }
    }
}
