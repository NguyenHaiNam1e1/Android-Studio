using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary1;
using System.Data.SqlClient;

namespace DoAnQuanLySach.GiaoDien
{
    public partial class FormDangNhap : Form
    {
        DBConnect conn;
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        public static class luuThongTin
        {
            public static string sever = "";
            public static string User = "";
            public static string Pass = "";
            public static string CSDL = "";
        }

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {      if (txtSV.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Sever");
            }
             else if (txtCSDL.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập CSDL");
            }
             else if (txtUSER.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập User");
            }
             else if (txtPass.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập pass");
            }
            else if (txtTaiKhoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
            }
            else if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Mật Khẩu");
            }
            else
            {


                luuThongTin.CSDL = txtCSDL.Text.Trim();
                luuThongTin.sever = txtSV.Text.Trim();
                luuThongTin.User = txtUSER.Text.Trim();
                luuThongTin.Pass = txtPass.Text.Trim();
                
                    
                    try
                    {
                        conn = new DBConnect("QuanLyNhaSach_QL", luuThongTin.sever, luuThongTin.CSDL, luuThongTin.User, luuThongTin.Pass);
                        //frmTacGia a = new frmTacGia(sever, CSDL, User, pass);
                        //frmThamGia b = new frmThamGia(sever, CSDL, User, pass);
                        //frmSuaSach c = new frmSuaSach(sever, CSDL, User, pass);
                        //frmSach d = new frmSach(sever, CSDL, User, pass);
                        //frmNhaXuatBan ad = new frmNhaXuatBan(sever, CSDL, User, pass);
                        //frmKhachHang ade = new frmKhachHang(sever, CSDL, User, pass);
                        //frmThemSach hj = new frmThemSach(sever, CSDL, User, pass);
                        //frmHoaDon hjk = new frmHoaDon(sever, CSDL, User, pass);

                        string strSQL = "select count(*) from dbo.NhanVien where TaiKhoan ='" + txtTaiKhoan.Text.Trim() + "' And MatKhau ='" + txtMatKhau.Text.Trim() + "'";
                        if (!conn.checkForExistence(strSQL))
                        {
                            MessageBox.Show("Tài khoản này chưa tồn tại");
                            txtMatKhau.Clear();
                            txtTaiKhoan.Clear();
                            txtTaiKhoan.Focus();
                        }
                        MessageBox.Show("Kết nối thành công! ");

                        FormSach frm = new FormSach();
                        frm.Sender(txtTaiKhoan.Text);
                        frm.Show();
                    }
                    catch
                    {
                        MessageBox.Show("vui lòng kiểm tra lại thông tin ");
                    }
                

             
               
            }
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ko ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
