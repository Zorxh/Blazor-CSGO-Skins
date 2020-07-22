using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSGOSkinsWeb.Database.Models
{
    public partial class WeaponCollection
    {
        public WeaponCollection()
        {
            Skin = new HashSet<Skin>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("collectionname")]
        [StringLength(255)]
        public string Collectionname { get; set; }
        [Column("introduced", TypeName = "date")]
        public DateTime? Introduced { get; set; }
        [Column("idstring")]
        [StringLength(255)]
        public string Idstring { get; set; }
        [Column("imgsrc")]
        [StringLength(1000)]
        public string Imgsrc { get; set; }

        [InverseProperty("WeapcollNavigation")]
        public virtual ICollection<Skin> Skin { get; set; }
    }
}
