using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                txtTen.Focus();
                txtMatKhau.Focus();
                if (txtTen.Text == "" && txtMatKhau.Text == "")
                {
                    throw new Exception("Vui lòng nhập tài khoản và mật khẩu");
                }
                if (txtMatKhau.Text=="")
                {
                    throw new Exception("Vui lòng nhập mật khẩu");
                }
               if(txtTen.Text=="")
                {
                    throw new Exception("Vui lòng nhập tài khoản");
                }
                else
                {
                    if (txtTen.Text != "admin")
                    {
                        throw new Exception("Sai tài khoản");
                    }
                    if (txtMatKhau.Text != "admin")
                    {
                        throw new Exception("Sai mật khẩu");
                    }
                }
                if(txtTen.Text=="admin"&&txtMatKhau.Text=="admin")
                {
                    NhaSach nhasach = new NhaSach();
                    this.Hide();
                    nhasach.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
