namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinCaNhan")]
    public partial class ThongTinCaNhan
    {
        [Key]
        [StringLength(15)]
        public string maNV { get; set; }

        [StringLength(70)]
        public string tenNV { get; set; }

        [StringLength(5)]
        public string gioiTinh { get; set; }

        public DateTime? ngaysinh { get; set; }

        [StringLength(15)]
        public string dienthoai { get; set; }

        [StringLength(100)]
        public string diaChi { get; set; }

        [StringLength(15)]
        public string maChuyenMon { get; set; }

        [StringLength(15)]
        public string maDanToc { get; set; }

        [StringLength(15)]
        public string maHonNhan { get; set; }

        [StringLength(15)]
        public string maTinh { get; set; }

        [StringLength(15)]
        public string maTonGiao { get; set; }

        [StringLength(15)]
        public string maTrinhDo { get; set; }
    }
}
