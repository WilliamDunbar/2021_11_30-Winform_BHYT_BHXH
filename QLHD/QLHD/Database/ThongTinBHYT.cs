namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinBHYT")]
    public partial class ThongTinBHYT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string maBHYT { get; set; }

        [StringLength(15)]
        public string maNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string maLanDong { get; set; }

        public DateTime? ngayCap { get; set; }

        public DateTime? ngayDong { get; set; }

        public int? giaTri { get; set; }

        public int? soTien { get; set; }

        [StringLength(2)]
        public string thang { get; set; }

        [StringLength(4)]
        public string nam { get; set; }

        [StringLength(15)]
        public string maNoiCap { get; set; }
    }
}
