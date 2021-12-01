using FontAwesome.Sharp;
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
    public partial class Trangchu : Form
    {
        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentChildForm;
        private int ImageNumber = 1;

        public Trangchu()
        {
            InitializeComponent();

        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FullScreen_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Maximized;
            else WindowState = FormWindowState.Normal;
        }

        #region Move
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void ScreenMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion Move

        //************
        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(92, 179, 99);
                currentButton.IconColor = Color.WhiteSmoke;
                currentButton.ImageAlign = ContentAlignment.MiddleCenter;
            }
        }
        private void ActivateButton(object senderbutton)
        {
            if (senderbutton != null)
            {
                DisableButton();
                currentButton = (IconButton)senderbutton;
                currentButton.BackColor = Color.WhiteSmoke;
                currentButton.IconColor = Color.FromArgb(92, 179, 99);
                currentButton.ImageAlign = ContentAlignment.MiddleCenter;
                //Left border button
                //leftBorderButton.BackColor = Color.FromArgb(92, 179, 99);
                //leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                //leftBorderButton.Visible = true;
                //leftBorderButton.BringToFront();
                ////Current Child Form Icon
                //currentButton.IconChar = currentButton.IconChar;
                //currentButton.IconColor = color;

            }
        }
        private void Reset()
        {
            DisableButton();

        }
        private void Home_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;

            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            panelDesktop.ForeColor = childForm.ForeColor;
            childForm.BringToFront();
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }



        private void Trangchu_Load(object sender, EventArgs e)
        {
            panelCheck.Parent = SliderPicture;
            btnPrevious.BackColor = Color.Transparent;
            btnPrevious.Parent = SliderPicture;
            btnNext.BackColor = Color.Transparent;
            btnNext.Parent = SliderPicture;
            using (Model_QuanLy_NhanSu qlns = new Model_QuanLy_NhanSu())
            {
              
                    TaiKhoan TK = qlns.TaiKhoans.Where(p => p.tenDangNhap == Login.tenDangNhap).FirstOrDefault();
                    accountChip.Text = TK.tenDangNhap;


            }
        }
        //************

        private void Slider()
        {
            if (ImageNumber == 5)
            {
                ImageNumber = 1;
            }
            else if (ImageNumber == 0)
            {
                ImageNumber = 4;
            }
            SliderPicture.ImageLocation = string.Format(@"References\{0}.jpg", ImageNumber);
            if (ImageNumber == 1) check1.Checked = true;
            else if (ImageNumber == 2) check2.Checked = true;
            else if (ImageNumber == 3) check3.Checked = true;
            else if (ImageNumber == 4) check4.Checked = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ImageNumber++;
            Slider();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ImageNumber--;
            timer1.Start();
            Slider();
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ImageNumber++;
            timer1.Start();
            Slider();
        }


        private void ShadowBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconBt_NhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new QuanLy_NhanVien());
        }

        private void iconBt_HDLD_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new QuanLy_HopDong());
        }

        private void iconBt_BHYT_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new QuanLy_BHYT());

        }

        private void iconBt_BHXH_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new QuanLy_BHXH());
        }

        
    }
}
