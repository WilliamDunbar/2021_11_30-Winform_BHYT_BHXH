namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongBan()
        {
            ChiTietHopDongs = new HashSet<ChiTietHopDong>();
        }

        [Key]
        [StringLength(15)]
        public string maPhongBan { get; set; }

        [StringLength(50)]
        public string tenPhongBan { get; set; }

        [StringLength(70)]
        public string diaChi { get; set; }

        [StringLength(15)]
        public string dienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; }
    }
}
