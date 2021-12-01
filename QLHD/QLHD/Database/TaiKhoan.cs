namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(10)]
        public string maTk { get; set; }

        [StringLength(15)]
        public string tenDangNhap { get; set; }

        [StringLength(15)]
        public string matKhau { get; set; }
    }
}
