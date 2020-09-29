using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQuanLySach.GiaoDien
{
    public partial class FormSach : Form
    {
        public delegate void SendMessage(string Message);
        public SendMessage Sender; 
        int PanelWidth;
        bool isCollapsed;

        public FormSach()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            AddFormSach();
        }

        private void GetMessage(string Message)
        {
            label5.Text = Message;
        }

        private void FormSach_Load(object sender, EventArgs e)
        {
           
        }

        public void AddFormSach()
        {
            // Xóa hết controls đang tồn tại trong pnlContain (nếu có)
            this.panelControls.Controls.Clear();
          
            frmSach sach = new frmSach();
            sach.TopLevel = false;

            // Gắn vào panel
            this.panelControls.Controls.Add(sach);

            // Hiển thị form
            sach.Show();
        }

        public void AddFormTacGia()
        {
            // Xóa hết controls đang tồn tại trong pnlContain (nếu có)
            this.panelControls.Controls.Clear();

            frmTacGia sach = new frmTacGia();
            sach.TopLevel = false;

            // Gắn vào panel
            this.panelControls.Controls.Add(sach);

            // Hiển thị form
            sach.Show();
        }

        public void AddFormNhaXuatBan()
        {
            // Xóa hết controls đang tồn tại trong pnlContain (nếu có)
            this.panelControls.Controls.Clear();

            frmNhaXuatBan sach = new frmNhaXuatBan();
            sach.TopLevel = false;

            // Gắn vào panel
            this.panelControls.Controls.Add(sach);

            // Hiển thị form
            sach.Show();
        }

        public void AddFormHoaDon()
        {
            // Xóa hết controls đang tồn tại trong pnlContain (nếu có)
            this.panelControls.Controls.Clear();

            frmHoaDon frm = new frmHoaDon();
            frm.Sender(label5.Text);

            frm.TopLevel = false;

            // Gắn vào panel
            this.panelControls.Controls.Add(frm);

            // Hiển thị form
            frm.Show();
        }

        public void AddFormKhachHang()
        {
            // Xóa hết controls đang tồn tại trong pnlContain (nếu có)
            this.panelControls.Controls.Clear();

            frmKhachHang sach = new frmKhachHang();
            sach.TopLevel = false;

            // Gắn vào panel
            this.panelControls.Controls.Add(sach);

            // Hiển thị form
            sach.Show();
        }
        public void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSach);
            AddFormSach();
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnTacGia);
            AddFormTacGia();
        }

        private void btnNhaXuatBan_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnNhaXuatBan);
            AddFormNhaXuatBan();
        }

        public void btnHoaDon_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHoaDon);
            AddFormHoaDon();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnKhachHang);
            AddFormKhachHang();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void FormSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ko ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }




    }
}
