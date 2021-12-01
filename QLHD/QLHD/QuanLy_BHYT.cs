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
    public partial class QuanLy_BHYT : Form
    {
        
        public static string MaDS;
        public static string TenDS;
        public bool ThemorSua;
        public QuanLy_BHYT()
        {
            InitializeComponent();
        }



        void Load_DauSach()
        {
            TrangThaiBanDau();
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
                var ListHD = qlns.Database.SqlQuery<ThongTinBHYT>("exec LoadThongTinBHYT");
                dtgv_BHYT.DataSource = ListHD.ToList();

            }

        }

        private void QuanLyBHYT_NV_Load(object sender, EventArgs e)
        {
            Load_DauSach();

        }

        void TrangThaiBanDau()
        {
            btnsave.Enabled = false;
            btnexit.Enabled = false;
            btThemHD.Enabled = true;
            btSuaHD.Enabled = true;
            txbMaBHYT.Enabled = false;
            txbLan.Enabled = false;
            txbtenNV.Enabled = false;
            dtNgayCap.Enabled = false;
            dtNgayDong.Enabled = false;
            txbGiaTri.Enabled = false;
            txbMaNV.Enabled = false;
            txbSoTien.Enabled = false;
            txbMaNoiCap.Enabled = false;
            txbTenNoiCap.Enabled = false;
            txbSdtNoiCap.Enabled = false;
            txbDiaChiNoiCap.Enabled = false;
        }

        void TrangThaiThemOrSuaDG()
        {
            btnsave.Enabled = true;
            btnexit.Enabled = true;
            btThemHD.Enabled = false;
            btSuaHD.Enabled = false;

            txbMaBHYT.Enabled = true;
            
            txbtenNV.Enabled = true;
            dtNgayCap.Enabled = true;
            dtNgayDong.Enabled = true;
            dtNgaySinh.Enabled = true;
            txbNamDong.Enabled = true;
            txbThang.Enabled = true;

            if(ThemorSua == true)
            {
                txbLan.Enabled = true;
                txbMaNV.Enabled = true;
                txbSoTien.Enabled = true;
                txbGiaTri.Enabled = true;
            }
            else if (ThemorSua == false)
            {
                txbLan.Enabled = false;
                txbMaNV.Enabled = false;
                txbSoTien.Enabled = false;
                txbGiaTri.Enabled = false;
            }
        }


        private void btThemHD_Click(object sender, EventArgs e)
        {
            ThemorSua = true;
            TrangThaiThemOrSuaDG();
            txbMaBHYT.Text = "";
            txbLan.Text = "";
            txbtenNV.Text = "";
            txbGiaTri.Text = "";
            txbMaNV.Text = "";
            txbThang.Text = "";
            txbNamDong.Text = "";
            txbSoTien.Text = "";
            txbMaNoiCap.Text = "";
            txbTenNoiCap.Text = "";
            txbSdtNoiCap.Text = "";
            txbDiaChiNoiCap.Text = "";
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
                    SqlParameter tongtien = new SqlParameter { ParameterName = "tongtien", Value = 0 };
                    SqlParameter maNV = new SqlParameter { ParameterName = "maNV", Value = txbMaNV.Text };
                    qlns.ThongTinHopDongs.SqlQuery($"exec TongLuongMoiNhat @maNV, @tongluong ", maNV, tongtien);
                    double sotien = int.Parse(tongtien.Value.ToString()) * 0.05;

                    int i = e.RowIndex;
                    txbMaBHYT.Text = dtgv_BHYT.Rows[i].Cells[0].Value.ToString();

                    txbMaNV.Text = dtgv_BHYT.Rows[i].Cells[1].Value.ToString();
                    NhanVien nhanVien = qlns.NhanViens.Where(p => p.maNV == txbMaNV.Text).FirstOrDefault();
                    txbtenNV.Text = nhanVien.tenNV;

                    txbLan.Text = dtgv_BHYT.Rows[i].Cells[2].Value.ToString();
                    dtNgayCap.Text = dtgv_BHYT.Rows[i].Cells[3].Value.ToString();
                    dtNgayDong.Text = dtgv_BHYT.Rows[i].Cells[4].Value.ToString();
                    txbGiaTri.Text = sotien.ToString();
                    txbSoTien.Text = txbGiaTri.Text;
                    txbThang.Text = dtgv_BHYT.Rows[i].Cells[7].Value.ToString();
                    txbNamDong.Text = dtgv_BHYT.Rows[i].Cells[8].Value.ToString();

                    txbMaNoiCap.Text = dtgv_BHYT.Rows[i].Cells[9].Value.ToString();
                    NoiCap noicap = qlns.NoiCaps.Where(p => p.maNoiCap.Equals(txbMaNoiCap.Text)).FirstOrDefault();
                    txbTenNoiCap.Text = noicap.tenNoiCap;
                    txbSdtNoiCap.Text = noicap.dienThoai;
                    txbDiaChiNoiCap.Text = noicap.diaChi;

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
                SqlParameter Search_NamDong = new SqlParameter { ParameterName = "nam", Value = txbTimKiem.Text };
                SqlParameter Search_MaNhanVien = new SqlParameter { ParameterName = "maNhanVien", Value = txbTimKiem.Text };
                if (rdbNamDong.Checked == true)
                {
                    var listNV = qlns.ThongTinBHYTs.SqlQuery($"exec TimKiemBHYT_TheoNamDong @nam", Search_NamDong);
                    dtgv_BHYT.DataSource = listNV.ToList();
                }
                else if ( rdbMaNhanVien.Checked == true)
                {
                    var listNV = qlns.ThongTinBHYTs.SqlQuery($"exec TimKiemBHYT_TheoMaNhanVien @maNhanVien", Search_MaNhanVien);
                    dtgv_BHYT.DataSource = listNV.ToList();
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
                SqlParameter tongtien = new SqlParameter { ParameterName = "tongtien", Value = 0 };
                SqlParameter maNV = new SqlParameter { ParameterName = "maNV", Value = txbMaNV.Text };
                qlns.ThongTinHopDongs.SqlQuery($"exec TongLuongMoiNhat @maNV, @tongluong ", maNV, tongtien);
                double sotien = int.Parse(tongtien.Value.ToString()) * 0.05;

                if (ThemorSua == true)
                {
                    var nopCap = new NoiCap
                    {
                        maNoiCap = txbMaNoiCap.Text,
                        tenNoiCap = txbTenNoiCap.Text,
                        dienThoai = txbSdtNoiCap.Text,
                        diaChi = txbDiaChiNoiCap.Text
                    };
                    var nhanVien = new NhanVien
                    {
                        maNV = txbMaNV.Text,
                        tenNV = txbtenNV.Text
                    };
                    var soBHYT = new SoBHYT
                    {
                        maBHYT = txbMaBHYT.Text,
                        maNV = txbMaNV.Text,
                        ngayCap = dtNgayCap.Value,
                        maNoiCap = txbMaNoiCap.Text,
                        giaTri = sotien
                    };
                    var chitiet_BHYT = new ChiTietDongBHYT
                    {
                        maBHYT = txbMaBHYT.Text,
                        maLanDong = txbLan.Text,
                        thang = txbThang.Text,
                        nam = txbNamDong.Text,
                        soTien = sotien
                    };

                    qlns.NoiCaps.Add(nopCap);
                    qlns.NhanViens.Add(nhanVien);
                    qlns.SoBHYTs.Add(soBHYT);
                    qlns.ChiTietDongBHYTs.Add(chitiet_BHYT);
                }
                else
                {
                    try
                    {
                        var _noiCap = qlns.NoiCaps.Where(p => p.tenNoiCap == txbTenNoiCap.Text).SingleOrDefault();
                        txbMaNoiCap.Text = _noiCap.maNoiCap;
                        _noiCap.diaChi = txbDiaChiNoiCap.Text;
                        _noiCap.dienThoai = txbSdtNoiCap.Text;
                        var _nhanVien = qlns.NhanViens.Where(p => p.tenNV == txbtenNV.Text).SingleOrDefault();
                        _nhanVien.maNV = txbMaNV.Text;
                        _nhanVien.tenNV = txbtenNV.Text;
                        var _soBHYT = qlns.SoBHYTs.Where(p => p.maBHYT == txbMaBHYT.Text).SingleOrDefault();
                        _soBHYT.maNV = txbMaNV.Text;
                        _soBHYT.ngayCap = dtNgayCap.Value;
                        _soBHYT.maNoiCap = txbMaNoiCap.Text;
                        _soBHYT.giaTri = sotien;
                        var _chitiet_BHYT = qlns.ChiTietDongBHYTs.Where(p => (p.maBHYT == txbMaBHYT.Text && p.maLanDong == txbLan.Text)).SingleOrDefault();
                        _chitiet_BHYT.thang = txbThang.Text;
                        _chitiet_BHYT.nam = txbNamDong.Text;
                        _chitiet_BHYT.soTien = sotien; 
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



        
    }
}