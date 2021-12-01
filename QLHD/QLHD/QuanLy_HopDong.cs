using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHD.Database;

namespace QLHD
{
    public partial class QuanLy_HopDong : Form
    {
        
        public static string MaDS;
        public static string TenDS;
        public bool ThemorSua;
        public QuanLy_HopDong()
        {
            InitializeComponent();
        }



        void Load_DauSach()
        {
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
                var ListHD = qlns.Database.SqlQuery<ThongTinHopDong>("exec LoadThongTinHopDong");
                dtgv_HopDong.DataSource = ListHD.ToList();

            }

        }

        private void QuanLyHopDong_NV_Load(object sender, EventArgs e)
        {
            Load_DauSach();

        }

        void TrangThaiBanDau()
        {
            btnsave.Enabled = false;
            btnexit.Enabled = false;
            btThemHD.Enabled = true;
            btSuaHD.Enabled = true;
            btXoaHD.Enabled = true;
            btnMoiNhat.Enabled = true;
            txbMaHD.Enabled = false;
            txbLan.Enabled = false;
            txbtenNV.Enabled = false;
            txbChucVu.Enabled = false;
            dtngayBD.Enabled = false;
            txbPhongBan.Enabled = false;
            txbLHD.Enabled = false;
            txbtenNguoiKy.Enabled = false;
            txbCVNguoiKy.Enabled = false;
            dtNgayHD.Enabled = false;
            txbMucLuon.Enabled = false;
            txbAnTrua.Enabled = false;
            txbTongLuong.Enabled = false;
            dtngayKT.Enabled = false;
            txbMaNV.Enabled = false;
            txbmaCV.Enabled = true;
            txbmaPhongBan.Enabled = false;
            txbmaLHD.Enabled = false;
            txbmaChucVuDK.Enabled = false;
            txbPCCV.Enabled = false;
        }

        void TrangThaiThemOrSuaDG()
        {
            btnsave.Enabled = true;
            btnexit.Enabled = true;
            btThemHD.Enabled = false;
            btSuaHD.Enabled = false;
            btXoaHD.Enabled = false;
            btnMoiNhat.Enabled = false;
            txbMaHD.Enabled = true;
            txbLan.Enabled = true;
            txbtenNV.Enabled = true;
            txbChucVu.Enabled = true;
            dtngayBD.Enabled = true;
            txbPhongBan.Enabled = true;
            txbLHD.Enabled = true;
            txbtenNguoiKy.Enabled = true;
            txbCVNguoiKy.Enabled = true;
            dtNgayHD.Enabled = true;
            txbMucLuon.Enabled = true;
            txbAnTrua.Enabled = true;
            txbTongLuong.Enabled = false;
            dtngayKT.Enabled = true;
            if(ThemorSua == true)
            {
                txbMaNV.Enabled = true;
                txbmaCV.Enabled = true;
                txbmaPhongBan.Enabled = true;
                txbmaLHD.Enabled = true;
                txbmaChucVuDK.Enabled = true;
                txbPCCV.Enabled = true;
            }
            else if (ThemorSua == false)
            {
                
                txbMaNV.Enabled = false;
                txbmaCV.Enabled = true;
                txbmaPhongBan.Enabled = false;
                txbmaLHD.Enabled = false;
                txbmaChucVuDK.Enabled = false;
                txbPCCV.Enabled = false;
            }
        }


        private void btThemHD_Click(object sender, EventArgs e)
        {
            ThemorSua = true;
            TrangThaiThemOrSuaDG();
            txbMaHD.Text = "";
            txbLan.Text = "";
            txbtenNV.Text = "";
            txbChucVu.Text = "";
            dtngayBD.Enabled = true;
            txbPhongBan.Text = "";
            txbLHD.Text = "";
            txbtenNguoiKy.Text = "";
            txbCVNguoiKy.Text = "";
            dtNgayHD.Enabled = true;
            txbMucLuon.Text = "";
            txbAnTrua.Text = "";
            txbTongLuong.Enabled = false;
            dtngayKT.Enabled = true;
            txbMaNV.Text = "";
            txbmaCV.Text = "";
            txbmaPhongBan.Text = "";
            txbmaLHD.Text = "";
            txbmaChucVuDK.Text = "";
            txbTongLuong.Text = "";
        }

        private void btSuaHD_Click(object sender, EventArgs e)
        {
            ThemorSua = false;
            TrangThaiThemOrSuaDG();
        }




        private void dtgv_HopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TrangThaiBanDau();
            try
            {
                using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
                {
                    int i = e.RowIndex;
                    txbMaHD.Text = dtgv_HopDong.Rows[i].Cells[0].Value.ToString();

                    txbMaNV.Text = dtgv_HopDong.Rows[i].Cells[1].Value.ToString();
                    NhanVien nhanVien = qlns.NhanViens.Where(p => p.maNV == txbMaNV.Text).FirstOrDefault();
                    txbtenNV.Text = nhanVien.tenNV;

                    txbLan.Text = dtgv_HopDong.Rows[i].Cells[2].Value.ToString();
                    dtngayBD.Text = dtgv_HopDong.Rows[i].Cells[3].Value.ToString();
                    dtngayKT.Text = dtgv_HopDong.Rows[i].Cells[4].Value.ToString();

                    txbmaPhongBan.Text = dtgv_HopDong.Rows[i].Cells[5].Value.ToString();
                    PhongBan phongban = qlns.PhongBans.Where(p => p.maPhongBan == txbmaPhongBan.Text).FirstOrDefault();
                    txbPhongBan.Text = phongban.tenPhongBan;

                    txbTongLuong.Text = dtgv_HopDong.Rows[i].Cells[6].Value.ToString();
                    txbtenNguoiKy.Text = dtgv_HopDong.Rows[i].Cells[7].Value.ToString();
                    dtNgayHD.Text = dtgv_HopDong.Rows[i].Cells[8].Value.ToString();
                    txbAnTrua.Text = dtgv_HopDong.Rows[i].Cells[9].Value.ToString();

                    txbmaLHD.Text = dtgv_HopDong.Rows[i].Cells[10].Value.ToString();
                    LoaiHopDong loaihd = qlns.LoaiHopDongs.Where(p => p.maLHD == txbmaLHD.Text).FirstOrDefault();
                    txbLHD.Text = loaihd.tenLHD;

                    txbmaCV.Text = dtgv_HopDong.Rows[i].Cells[11].Value.ToString();
                    ChucVu chucvu = qlns.ChucVus.Where(p => p.maChucVu == txbmaCV.Text).FirstOrDefault();
                    txbChucVu.Text = chucvu.tenChucVu;

                    txbMucLuon.Text = dtgv_HopDong.Rows[i].Cells[12].Value.ToString();

                    txbmaChucVuDK.Text = dtgv_HopDong.Rows[i].Cells[13].Value.ToString();
                    ChucVu chucvunguoiky = qlns.ChucVus.Where(p => p.maChucVu == txbmaChucVuDK.Text).FirstOrDefault();
                    txbCVNguoiKy.Text = chucvunguoiky.tenChucVu;

                    txbGhiChu.Text = dtgv_HopDong.Rows[i].Cells[14].Value.ToString();

                }
            }
            catch (Exception)
            {

            }


        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
                SqlParameter Search_Landong = new SqlParameter { ParameterName = "lanDong", Value = txbTimKiem.Text };
                SqlParameter Search_MaNhanVien = new SqlParameter { ParameterName = "MaNhanVien", Value = txbTimKiem.Text };
                SqlParameter Search_MaPhongBan = new SqlParameter { ParameterName = "MaPhongBan", Value = txbTimKiem.Text };
                if (rdbLanDong.Checked == true)
                {
                    var listNV = qlns.ThongTinHopDongs.SqlQuery($"exec TimKiemHopDong_TheoLanDong @lanDong", Search_Landong);
                    dtgv_HopDong.DataSource = listNV.ToList();
                }
                else if (rdbTenNhanVien.Checked == true)
                {
                    var listNV = qlns.ThongTinHopDongs.SqlQuery($"exec TimKiemHopDong_TheoMaNhanVien @maNhanVien", Search_MaNhanVien);
                    dtgv_HopDong.DataSource = listNV.ToList();
                }
                else if (rdbPhongBan.Checked == true)
                {
                    var listNV = qlns.ThongTinHopDongs.SqlQuery($"exec TimKiemHopDong_TheoMaPhongBan @maPhongBan", Search_MaPhongBan);
                    dtgv_HopDong.DataSource = listNV.ToList();
                }
            }
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            TrangThaiBanDau();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
                
                if(ThemorSua == true)
                {
                    var loaihopdong = new LoaiHopDong
                    {
                        maLHD = txbmaLHD.Text,
                        tenLHD = txbLHD.Text
                    };
                    var hopdongld = new HopDongLD
                    {
                        maHD = txbMaHD.Text,
                        maNV = txbMaNV.Text,
                        ghiChu = txbGhiChu.Text
                    };
                    var chucvu = new ChucVu
                    {
                        maChucVu = txbmaCV.Text,
                        tenChucVu = txbChucVu.Text,
                        phuCapChucVu = int.Parse(txbPCCV.Text)
                    };
                    var chucvuNguoiky = new ChucVu
                    {
                        maChucVu = txbmaChucVuDK.Text,
                        tenChucVu = txbCVNguoiKy.Text
                    };
                    var phongban = new PhongBan
                    {
                        maPhongBan = txbmaPhongBan.Text,
                        tenPhongBan = txbPhongBan.Text
                    };
                    var nhanvien = new NhanVien
                    {
                        maNV = txbMaNV.Text,
                        tenNV = txbtenNV.Text
                    };
                    var hopdong = new ChiTietHopDong
                    {
                        maHD = txbMaHD.Text,
                        maLanHD = txbLan.Text,
                        ngayBD = dtngayBD.Value,
                        ngayKT = dtngayKT.Value,
                        maPhongBan = txbmaPhongBan.Text,
                        tongLuong = (int.Parse(txbPCCV.Text) + int.Parse(txbMucLuon.Text) + int.Parse(txbAnTrua.Text)),
                        nguoiKy = txbtenNguoiKy.Text,
                        ngayHD = dtNgayHD.Value,
                        anTrua = int.Parse(txbAnTrua.Text),
                        maLHD = txbmaLHD.Text,
                        maChucVu = txbChucVu.Text,
                        mucLuong = int.Parse(txbMucLuon.Text),
                        maChucVuNguoiKy = txbmaChucVuDK.Text
                    };
                    qlns.LoaiHopDongs.Add(loaihopdong);
                    qlns.HopDongLDs.Add(hopdongld);
                    qlns.ChucVus.Add(chucvu);
                    qlns.ChucVus.Add(chucvuNguoiky);
                    qlns.PhongBans.Add(phongban);
                    qlns.NhanViens.Add(nhanvien);
                    qlns.ChiTietHopDongs.Add(hopdong);
                }
                else
                {
                    try
                    {
                        var _loaihopdong = qlns.LoaiHopDongs.Where(p => p.tenLHD == txbLHD.Text).SingleOrDefault();
                        txbmaLHD.Text = _loaihopdong.maLHD;
                        var _chucvu = qlns.ChucVus.Where(p => p.tenChucVu == txbChucVu.Text).SingleOrDefault();
                        txbmaCV.Text = _chucvu.maChucVu;
                        txbPCCV.Text = _chucvu.phuCapChucVu.ToString();
                        var _chucvuNguoiky = qlns.ChucVus.Where(p => p.tenChucVu == txbCVNguoiKy.Text).SingleOrDefault();
                        txbmaChucVuDK.Text = _chucvuNguoiky.maChucVu;
                        var _phongban = qlns.PhongBans.Where(p => p.tenPhongBan == txbPhongBan.Text).SingleOrDefault();
                        txbmaPhongBan.Text = _phongban.maPhongBan;
                        var _nhanvien = qlns.NhanViens.Where(p => p.tenNV == txbtenNV.Text).SingleOrDefault();
                        txbMaNV.Text = _nhanvien.maNV;
                        var _hopdongld = qlns.HopDongLDs.Where(p => p.maHD == txbMaHD.Text).SingleOrDefault();
                        _hopdongld.maNV = txbMaNV.Text;
                        _hopdongld.ghiChu = txbGhiChu.Text;
                        var _hopdong = qlns.ChiTietHopDongs.Where(p => p.maHD == txbMaHD.Text).SingleOrDefault();
                        _hopdong.maHD = txbMaHD.Text;
                        _hopdong.maLanHD = txbLan.Text;
                        _hopdong.ngayBD = dtngayBD.Value;
                        _hopdong.ngayKT = dtngayKT.Value;
                        _hopdong.maPhongBan = txbmaPhongBan.Text;
                        _hopdong.tongLuong = int.Parse(txbPCCV.Text) + _hopdong.mucLuong + _hopdong.anTrua;
                        _hopdong.nguoiKy = txbtenNguoiKy.Text;
                        _hopdong.ngayHD = dtNgayHD.Value;
                        _hopdong.anTrua = int.Parse(txbAnTrua.Text);
                        _hopdong.maLHD = txbmaLHD.Text;
                        _hopdong.maChucVu = txbmaCV.Text;
                        _hopdong.mucLuong = int.Parse(txbMucLuon.Text);
                        _hopdong.maChucVuNguoiKy = txbmaChucVuDK.Text;
                        qlns.SaveChanges();
                    }
                    catch (DbEntityValidationException c)
                    {
                        foreach (var eve in c.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                    
                }
                TrangThaiBanDau();

            }
        }

        private void btnMoiNhat_Click(object sender, EventArgs e)
        {
            try
            {
                using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
                {
                    var Latest = new List<ThongTinHopDong>();
                    SqlParameter maNV = new SqlParameter { ParameterName = "maNV", Value = txbMaNV.Text };
                    var latestobject = qlns.Database.SqlQuery<ThongTinHopDong>("exec HopDongMoiNhat @maNV", maNV);
                    Latest = latestobject.ToList();

                    int i = 0;
                    txbMaHD.Text = Latest[0].maHD;

                    txbMaNV.Text = Latest[0].maNV;
                    NhanVien nhanVien = qlns.NhanViens.Where(p => p.maNV == txbMaNV.Text).FirstOrDefault();
                    txbtenNV.Text = nhanVien.tenNV;

                    txbLan.Text = Latest[0].maLanHD; ;
                    dtngayBD.Text = Latest[0].ngayBD.ToString();
                    dtngayKT.Text = Latest[0].ngayKT.ToString();

                    txbmaPhongBan.Text = Latest[0].maPhongBan;
                    PhongBan phongban = qlns.PhongBans.Where(p => p.maPhongBan == txbmaPhongBan.Text).FirstOrDefault();
                    txbPhongBan.Text = phongban.tenPhongBan;

                    
                    txbtenNguoiKy.Text = Latest[0].nguoiKy;
                    dtNgayHD.Text = Latest[0].ngayHD.ToString();
                    txbAnTrua.Text = Latest[0].anTrua.ToString();

                    txbmaLHD.Text = Latest[0].maLHD;
                    LoaiHopDong loaihd = qlns.LoaiHopDongs.Where(p => p.maLHD == txbmaLHD.Text).FirstOrDefault();
                    txbLHD.Text = loaihd.tenLHD;

                    txbmaCV.Text = Latest[0].maChucVu;
                    ChucVu chucvu = qlns.ChucVus.Where(p => p.maChucVu == txbmaCV.Text).FirstOrDefault();
                    txbChucVu.Text = chucvu.tenChucVu;
                    txbPCCV.Text = chucvu.phuCapChucVu.ToString();



                    txbTongLuong.Text = (Latest[0].mucLuong + Latest[0].anTrua + chucvu.phuCapChucVu).ToString();
                    txbMucLuon.Text = Latest[0].mucLuong.ToString();

                    txbmaChucVuDK.Text = Latest[0].maChucVuNguoiKy;
                    ChucVu chucvunguoiky = qlns.ChucVus.Where(p => p.maChucVu == txbmaChucVuDK.Text).FirstOrDefault();
                    txbCVNguoiKy.Text = chucvunguoiky.tenChucVu;

                    txbGhiChu.Text = Latest[0].ghiChu;

                }
            }
            catch (Exception)
            {

            }
        }

        private void btXoaHD_Click(object sender, EventArgs e)
        {
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
                try
                {
                    var tthd = qlns.ChiTietHopDongs.Where(p => p.maHD.Equals(txbMaHD.Text)).FirstOrDefault();
                    qlns.ChiTietHopDongs.Remove(tthd);
                    var hdld = qlns.HopDongLDs.Where(p => p.maHD.Equals(txbMaHD.Text)).FirstOrDefault();
                    qlns.HopDongLDs.Remove(hdld);
                    qlns.SaveChanges();
                }
                catch (DbEntityValidationException c)
                {
                    foreach (var eve in c.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }
        }
    }
}