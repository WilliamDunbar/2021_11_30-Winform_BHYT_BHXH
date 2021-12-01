namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHopDong")]
    public partial class ChiTietHopDong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string maHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string maLanHD { get; set; }

        public DateTime? ngayHD { get; set; }

        [StringLength(15)]
        public string maLHD { get; set; }

        public DateTime? ngayBD { get; set; }

        public DateTime? ngayKT { get; set; }

        [StringLength(15)]
        public string maPhongBan { get; set; }

        [StringLength(15)]
        public string maChucVu { get; set; }

        public int? mucLuong { get; set; }

        public int? anTrua { get; set; }

        public int? tongLuong { get; set; }

        [StringLength(30)]
        public string nguoiKy { get; set; }

        [StringLength(15)]
        public string maChucVuNguoiKy { get; set; }

        public virtual LoaiHopDong LoaiHopDong { get; set; }

        public virtual PhongBan PhongBan { get; set; }

        public virtual HopDongLD HopDongLD { get; set; }
    }
}
