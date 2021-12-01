namespace QLHD.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public partial class ChucVu
    {
        [Key]
        [StringLength(15)]
        public string maChucVu { get; set; }

        [StringLength(50)]
        public string tenChucVu { get; set; }

        public int? phuCapChucVu { get; set; }
    }
}
