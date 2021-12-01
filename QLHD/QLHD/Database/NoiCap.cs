namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoiCap")]
    public partial class NoiCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NoiCap()
        {
            SoBHXHs = new HashSet<SoBHXH>();
            SoBHYTs = new HashSet<SoBHYT>();
        }

        [Key]
        [StringLength(15)]
        public string maNoiCap { get; set; }

        [StringLength(50)]
        public string tenNoiCap { get; set; }

        [StringLength(70)]
        public string diaChi { get; set; }

        [StringLength(15)]
        public string dienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoBHXH> SoBHXHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoBHYT> SoBHYTs { get; set; }
    }
}
