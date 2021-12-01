using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class QuanLy_NhanVien : Form
    {

        bool ThemOrSua;

        public QuanLy_NhanVien()
        {
            InitializeComponent();
        }
        public void Load_NV()
        {
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
                var listNV = qlns.Database.SqlQuery<ThongTinCaNhan>($"exec LoadThongTinNhanVien");
                dtgv_loadNV.DataSource = listNV.ToList();

            }

        }

        private void QuanLy_NhanVien_Load(object sender, EventArgs e)
        {
            Load_NV();
        }

        private void dtgv_loadNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
                {
                    int i = e.RowIndex;
                    txbMaNV.Text = dtgv_loadNV.Rows[i].Cells[0].Value.ToString();
                    txbTenNV.Text = dtgv_loadNV.Rows[i].Cells[1].Value.ToString();

                    /*txbTinh.Text = dtgv_loadNV.Rows[i].Cells[4].Value.ToString();
                    Tinh tinh = qlns.Tinhs.Where(p => p.maTinh == txbTinh.Text).FirstOrDefault();
                    txbTinh.Text = tinh.tenTinh;*/

                    dtpNgaySinh.Text = dtgv_loadNV.Rows[i].Cells[3].Value.ToString();
                    txbSdt.Text = dtgv_loadNV.Rows[i].Cells[4].Value.ToString();
                    txbDiaChi.Text = dtgv_loadNV.Rows[i].Cells[5].Value.ToString();

                    txbTD.Text = dtgv_loadNV.Rows[i].Cells[11].Value.ToString();
                    TrinhDoVH trinhdo = qlns.TrinhDoVHs.Where(p => p.maTrinhDo == txbTD.Text).FirstOrDefault();
                    txbTD.Text = trinhdo.tenTrinhDo;

                    txbCM.Text = dtgv_loadNV.Rows[i].Cells[6].Value.ToString();
                    ChuyenMon chuyenmon = qlns.ChuyenMons.Where(p => p.maChuyenMon == txbCM.Text).FirstOrDefault();
                    txbCM.Text = chuyenmon.tenChuyenMon;

                    txbDanToc.Text = dtgv_loadNV.Rows[i].Cells[7].Value.ToString();
                    DanToc dantoc = qlns.DanTocs.Where(p => p.maDanToc == txbDanToc.Text).FirstOrDefault();
                    txbDanToc.Text = dantoc.tenDanToc;

                    txbTG.Text = dtgv_loadNV.Rows[i].Cells[10].Value.ToString();
                    TonGiao tongiao = qlns.TonGiaos.Where(p => p.maTonGiao == txbTG.Text).FirstOrDefault();
                    txbTG.Text = tongiao.tenTonGiao;

                    txbHN.Text = dtgv_loadNV.Rows[i].Cells[8].Value.ToString();
                    HonNhan honnhan = qlns.HonNhans.Where(p => p.maHonNhan == txbHN.Text).FirstOrDefault();
                    txbHN.Text = honnhan.tenHonNhan;

                    NhanVien nv = qlns.NhanViens.Where(p => p.maNV == txbMaNV.Text).FirstOrDefault();
                    Byte_HinhAnh = (byte[])nv.hinhAnh;
                    ptbAnhDS.Image = ByteToImage((byte[])nv.hinhAnh);

                }
            }
            catch (Exception)
            {

            }
        }

        private byte[] ConvertImageToBytes(string text)
        {
            FileStream fs;
            fs = new FileStream(text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;

        }
        string textImagePath;
        byte[] Byte_HinhAnh;
        private void ptbAnhDS_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog OpenFDL = new OpenFileDialog();
            OpenFDL.Filter = OpenFDL.Filter = "JPG files (.jpg)|.jpg|All files (.)|*.*";
            OpenFDL.FilterIndex = 1;
            OpenFDL.RestoreDirectory = true;
            if (OpenFDL.ShowDialog() == DialogResult.OK)
            {
                ptbAnhDS.ImageLocation = OpenFDL.FileName;
                textImagePath = OpenFDL.FileName.ToString();
            }
            Byte_HinhAnh = ConvertImageToBytes(textImagePath);
            ptbAnhDS.Image = ByteToImage(Byte_HinhAnh);
        }
        public static Image ByteToImage(byte[] arrImage)
        {
            if (arrImage == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(arrImage, 0, arrImage.Length);
            ms.Write(arrImage, 0, arrImage.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
                SqlParameter Search_Ma = new SqlParameter { ParameterName = "MaDocGia", Value = txbTimKiem.Text };
                SqlParameter Search_Ten = new SqlParameter { ParameterName = "TenDocGia", Value = txbTimKiem.Text };
                if (rdbMaNV.Checked == true)
                {
                    var listNV = qlns.ThongTinCaNhans.SqlQuery($"exec TimKiemNhanVien_TheoMa @MaDocGia", Search_Ma);
                    dtgv_loadNV.DataSource = listNV.ToList();
                }
                else if (rdbTenNV.Checked == true)
                {
                    var listNV = qlns.ThongTinCaNhans.SqlQuery($"exec TimKiemNhanVien_TheoTen @TenDocGia", Search_Ten);
                    dtgv_loadNV.DataSource = listNV.ToList();
                }
            }
        }
    }
}

