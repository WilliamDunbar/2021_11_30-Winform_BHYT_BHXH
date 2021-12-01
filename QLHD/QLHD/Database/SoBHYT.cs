namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoBHYT")]
    public partial class SoBHYT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoBHYT()
        {
            ChiTietDongBHYTs = new HashSet<ChiTietDongBHYT>();
        }

        [Key]
        [StringLength(15)]
        public string maBHYT { get; set; }

        [StringLength(15)]
        public string maNV { get; set; }

        public DateTime? ngayCap { get; set; }

        [StringLength(15)]
        public string maNoiCap { get; set; }

        public double? giaTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDongBHYT> ChiTietDongBHYTs { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NoiCap NoiCap { get; set; }
    }
}
