namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDongLD")]
    public partial class HopDongLD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HopDongLD()
        {
            ChiTietHopDongs = new HashSet<ChiTietHopDong>();
        }

        [Key]
        [StringLength(15)]
        public string maHD { get; set; }

        [StringLength(15)]
        public string maNV { get; set; }

        [StringLength(3000)]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
