using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSGOSkinsWeb.Database.Models
{
    public partial class WeaponCase
    {
        public WeaponCase()
        {
            Skin = new HashSet<Skin>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("casename")]
        [StringLength(255)]
        public string Casename { get; set; }
        [Column("casecollection")]
        [StringLength(255)]
        public string Casecollection { get; set; }
        [Column("introduced", TypeName = "date")]
        public DateTime? Introduced { get; set; }
        [Column("idstring")]
        [StringLength(255)]
        public string Idstring { get; set; }
        [Column("imgsrc")]
        [StringLength(1000)]
        public string Imgsrc { get; set; }

        [InverseProperty("WeapcaseNavigation")]
        public virtual ICollection<Skin> Skin { get; set; }
    }
}
