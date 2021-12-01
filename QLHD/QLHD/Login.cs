using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHD.Database;

namespace QLHD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xemMK_Click(object sender, EventArgs e)
        {
            if(txbMatKhau.UseSystemPasswordChar == true)
            {
                txbMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txbMatKhau.UseSystemPasswordChar = true;
            }
            
        }

        public static string tenDangNhap;
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {

                    TaiKhoan tkNV = qlns.TaiKhoans.Where(p => p.tenDangNhap == txbTenDangNhap.Text && p.matKhau == txbMatKhau.Text).SingleOrDefault();

                    if (tkNV == null) MessageBox.Show("Ten dang nhap hoac mat khau khong dung!");
                    else
                    {
                    tenDangNhap = tkNV.tenDangNhap;
                    //ThuThuOrDocGia = true;
                    Form fr = new Trangchu();
                        this.Visible = false;
                        fr.ShowDialog();
                        this.Close();
                    }
            }
        }
        #region Move
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion Move

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
