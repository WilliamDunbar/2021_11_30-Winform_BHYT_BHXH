namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinHopDong")]
    public partial class ThongTinHopDong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string maHD { get; set; }

        [StringLength(15)]
        public string maNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string maLanHD { get; set; }

        public DateTime? ngayBD { get; set; }

        public DateTime? ngayKT { get; set; }

        [StringLength(15)]
        public string maPhongBan { get; set; }

        public int? tongLuong { get; set; }

        [StringLength(30)]
        public string nguoiKy { get; set; }

        public DateTime? ngayHD { get; set; }

        public int? anTrua { get; set; }

        [StringLength(15)]
        public string maLHD { get; set; }

        [StringLength(15)]
        public string maChucVu { get; set; }

        public int? mucLuong { get; set; }

        [StringLength(15)]
        public string maChucVuNguoiKy { get; set; }

        [StringLength(3000)]
        public string ghiChu { get; set; }
    }
}
