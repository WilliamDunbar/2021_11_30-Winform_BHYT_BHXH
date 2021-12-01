namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HopDongLDs = new HashSet<HopDongLD>();
            SoBHXHs = new HashSet<SoBHXH>();
            SoBHYTs = new HashSet<SoBHYT>();
        }

        [Key]
        [StringLength(15)]
        public string maNV { get; set; }

        public DateTime? ngaysinh { get; set; }

        [StringLength(15)]
        public string maDanToc { get; set; }

        [StringLength(15)]
        public string maTonGiao { get; set; }

        [StringLength(15)]
        public string maTinh { get; set; }

        [StringLength(15)]
        public string maTrinhDo { get; set; }

        [StringLength(5)]
        public string gioiTinh { get; set; }

        [StringLength(15)]
        public string dienthoai { get; set; }

        [StringLength(15)]
        public string maHonNhan { get; set; }

        [StringLength(15)]
        public string maChuyenMon { get; set; }

        [StringLength(100)]
        public string diaChi { get; set; }

        [StringLength(70)]
        public string tenNV { get; set; }

        [Column(TypeName = "image")]
        public byte[] hinhAnh { get; set; }

        public virtual ChuyenMon ChuyenMon { get; set; }

        public virtual DanToc DanToc { get; set; }

        public virtual HonNhan HonNhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongLD> HopDongLDs { get; set; }

        public virtual Tinh Tinh { get; set; }

        public virtual TonGiao TonGiao { get; set; }

        public virtual TrinhDoVH TrinhDoVH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoBHXH> SoBHXHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoBHYT> SoBHYTs { get; set; }
    }
}
