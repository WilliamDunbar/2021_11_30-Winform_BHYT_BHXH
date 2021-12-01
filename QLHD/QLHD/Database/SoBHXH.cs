namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoBHXH")]
    public partial class SoBHXH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoBHXH()
        {
            ChiTietDongBHXHs = new HashSet<ChiTietDongBHXH>();
        }

        [Key]
        [StringLength(15)]
        public string maBHXH { get; set; }

        [StringLength(15)]
        public string maNV { get; set; }

        public DateTime? ngayCap { get; set; }

        [StringLength(15)]
        public string maNoiCap { get; set; }

        public double? giaTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDongBHXH> ChiTietDongBHXHs { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NoiCap NoiCap { get; set; }
    }
}
