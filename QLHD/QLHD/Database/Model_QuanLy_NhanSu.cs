using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLHD.Database
{
    public partial class Model_QuanLy_NhanSu : DbContext
    {
        public Model_QuanLy_NhanSu()
            : base("name=Model_QuanLy_NhanSu")
        {
        }

        public virtual DbSet<ChiTietDongBHXH> ChiTietDongBHXHs { get; set; }
        public virtual DbSet<ChiTietDongBHYT> ChiTietDongBHYTs { get; set; }
        public virtual DbSet<ChiTietHopDong> ChiTietHopDongs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChuyenMon> ChuyenMons { get; set; }
        public virtual DbSet<DanToc> DanTocs { get; set; }
        public virtual DbSet<HonNhan> HonNhans { get; set; }
        public virtual DbSet<HopDongLD> HopDongLDs { get; set; }
        public virtual DbSet<LoaiHopDong> LoaiHopDongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NoiCap> NoiCaps { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<SoBHXH> SoBHXHs { get; set; }
        public virtual DbSet<SoBHYT> SoBHYTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Tinh> Tinhs { get; set; }
        public virtual DbSet<TonGiao> TonGiaos { get; set; }
        public virtual DbSet<TrinhDoVH> TrinhDoVHs { get; set; }
        public virtual DbSet<ThongTinBHXH> ThongTinBHXHs { get; set; }
        public virtual DbSet<ThongTinBHYT> ThongTinBHYTs { get; set; }
        public virtual DbSet<ThongTinCaNhan> ThongTinCaNhans { get; set; }
        public virtual DbSet<ThongTinHopDong> ThongTinHopDongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDongBHXH>()
                .Property(e => e.maBHXH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDongBHXH>()
                .Property(e => e.maLanDong)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDongBHXH>()
                .Property(e => e.thang)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDongBHXH>()
                .Property(e => e.nam)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDongBHYT>()
                .Property(e => e.maBHYT)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDongBHYT>()
                .Property(e => e.maLanDong)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDongBHYT>()
                .Property(e => e.thang)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDongBHYT>()
                .Property(e => e.nam)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDong>()
                .Property(e => e.maHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDong>()
                .Property(e => e.maLanHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDong>()
                .Property(e => e.maLHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDong>()
                .Property(e => e.maPhongBan)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDong>()
                .Property(e => e.maChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDong>()
                .Property(e => e.maChucVuNguoiKy)
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .Property(e => e.maChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenMon>()
                .Property(e => e.maChuyenMon)
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenMon>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.ChuyenMon)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DanToc>()
                .Property(e => e.maDanToc)
                .IsUnicode(false);

            modelBuilder.Entity<DanToc>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.DanToc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<HonNhan>()
                .Property(e => e.maHonNhan)
                .IsUnicode(false);

            modelBuilder.Entity<HonNhan>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.HonNhan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<HopDongLD>()
                .Property(e => e.maHD)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongLD>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHopDong>()
                .Property(e => e.maLHD)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHopDong>()
                .HasMany(e => e.ChiTietHopDongs)
                .WithOptional(e => e.LoaiHopDong)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maDanToc)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maTonGiao)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maTinh)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maTrinhDo)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maHonNhan)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maChuyenMon)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HopDongLDs)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.SoBHXHs)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.SoBHYTs)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NoiCap>()
                .Property(e => e.maNoiCap)
                .IsUnicode(false);

            modelBuilder.Entity<NoiCap>()
                .Property(e => e.dienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NoiCap>()
                .HasMany(e => e.SoBHXHs)
                .WithOptional(e => e.NoiCap)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NoiCap>()
                .HasMany(e => e.SoBHYTs)
                .WithOptional(e => e.NoiCap)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.maPhongBan)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.dienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.ChiTietHopDongs)
                .WithOptional(e => e.PhongBan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SoBHXH>()
                .Property(e => e.maBHXH)
                .IsUnicode(false);

            modelBuilder.Entity<SoBHXH>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<SoBHXH>()
                .Property(e => e.maNoiCap)
                .IsUnicode(false);

            modelBuilder.Entity<SoBHYT>()
                .Property(e => e.maBHYT)
                .IsUnicode(false);

            modelBuilder.Entity<SoBHYT>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<SoBHYT>()
                .Property(e => e.maNoiCap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.maTk)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<Tinh>()
                .Property(e => e.maTinh)
                .IsUnicode(false);

            modelBuilder.Entity<Tinh>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.Tinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TonGiao>()
                .Property(e => e.maTonGiao)
                .IsUnicode(false);

            modelBuilder.Entity<TonGiao>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.TonGiao)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrinhDoVH>()
                .Property(e => e.maTrinhDo)
                .IsUnicode(false);

            modelBuilder.Entity<TrinhDoVH>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.TrinhDoVH)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinBHXH>()
                .Property(e => e.maBHXH)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHXH>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHXH>()
                .Property(e => e.maLanDong)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHXH>()
                .Property(e => e.thang)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHXH>()
                .Property(e => e.nam)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHXH>()
                .Property(e => e.maNoiCap)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHYT>()
                .Property(e => e.maBHYT)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHYT>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHYT>()
                .Property(e => e.maLanDong)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHYT>()
                .Property(e => e.thang)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHYT>()
                .Property(e => e.nam)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBHYT>()
                .Property(e => e.maNoiCap)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.maChuyenMon)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.maDanToc)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.maHonNhan)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.maTinh)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.maTonGiao)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.maTrinhDo)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinHopDong>()
                .Property(e => e.maHD)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinHopDong>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinHopDong>()
                .Property(e => e.maLanHD)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinHopDong>()
                .Property(e => e.maPhongBan)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinHopDong>()
                .Property(e => e.maLHD)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinHopDong>()
                .Property(e => e.maChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinHopDong>()
                .Property(e => e.maChucVuNguoiKy)
                .IsUnicode(false);
        }
    }
}
