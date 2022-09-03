using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class NhaSach : Form
    {
        public NhaSach()
        {
            InitializeComponent();
        }


        private void XoaThongTin_KhoSach()
        {
            txtGiaBan.Text = "";
            txtLoaiSach.Text = "";
            txtMaSach.Text = "";
            txtSoLuong.Text = "";
            txtTacGia.Text = "";
            txtTenSach.Text = "";
        }
        private void XoaThongTin_BanSach()
        {
            txtMaSach1.Text = "";
            txtTenSach1.Text = "";
            dtpNgay.Value = DateTime.Now;
            txtSoLuong1.Text = "";
         
        }
        private void ListView_Kho()
        {
            lvKho.Columns[0].Width = (int)(lvKho.Width * 0.11);
            lvKho.Columns[1].Width = (int)(lvKho.Width * 0.26);
            lvKho.Columns[2].Width = (int)(lvKho.Width * 0.1);
            lvKho.Columns[3].Width = (int)(lvKho.Width * 0.21);
            lvKho.Columns[4].Width = (int)(lvKho.Width * 0.21);
            lvKho.Columns[5].Width = (int)(lvKho.Width * 0.11);
        }
        private void ListView_TimKiem()
        {
            lvTimKiem.Columns[0].Width = (int)(lvTimKiem.Width * 0.25);
            lvTimKiem.Columns[1].Width = (int)(lvTimKiem.Width * 0.25);
            lvTimKiem.Columns[2].Width = (int)(lvTimKiem.Width * 0.25);
            lvTimKiem.Columns[3].Width = (int)(lvTimKiem.Width * 0.25);
        }
        private void ListView_Ban()
        {
            lvBan.Columns[0].Width = (int)(lvBan.Width * 0.1);
            lvBan.Columns[1].Width = (int)(lvBan.Width * 0.4);
            lvBan.Columns[2].Width = (int)(lvBan.Width * 0.1);
            lvBan.Columns[3].Width = (int)(lvBan.Width * 0.15);
            lvBan.Columns[4].Width = (int)(lvBan.Width * 0.15);
            lvBan.Columns[5].Width = (int)(lvBan.Width * 0.1);
        }
        private void ListView_DoanhThu()
        {
            lvDoanhThu.Columns[0].Width = (int)(lvDoanhThu.Width * 0.1);
            lvDoanhThu.Columns[1].Width = (int)(lvDoanhThu.Width * 0.1);
            lvDoanhThu.Columns[2].Width = (int)(lvDoanhThu.Width * 0.4);
            lvDoanhThu.Columns[3].Width = (int)(lvDoanhThu.Width * 0.1);
            lvDoanhThu.Columns[4].Width = (int)(lvDoanhThu.Width * 0.15);
            lvDoanhThu.Columns[5].Width = (int)(lvDoanhThu.Width * 0.15);
        }
        private void ListView_SachBan()
        {
            lvSachBan.Columns[0].Width = (int)(lvSachBan.Width * 0.1);
            lvSachBan.Columns[1].Width = (int)(lvSachBan.Width * 0.1);
            lvSachBan.Columns[2].Width = (int)(lvSachBan.Width * 0.4);
            lvSachBan.Columns[3].Width = (int)(lvSachBan.Width * 0.1);
            lvSachBan.Columns[4].Width = (int)(lvSachBan.Width * 0.15);
            lvSachBan.Columns[5].Width = (int)(lvSachBan.Width * 0.15);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            bool co = true;
       
            if (txtGiaBan.Text != "" && txtLoaiSach.Text != "" && txtMaSach.Text != "" && txtSoLuong.Text != "" && txtTacGia.Text != "" && txtTenSach.Text != "")
            {
                try
                {
                    int soLuong = Convert.ToInt32(txtSoLuong.Text);
                    try
                    {
                        int giaBan = Convert.ToInt32(txtGiaBan.Text);
                        
                        for (int i = 0; i < lvKho.Items.Count; i++)//đã có , tăng số lượng 
                        {
                            if (lvKho.Items[i].SubItems[0].Text==txtMaSach.Text && lvKho.Items[i].SubItems[1].Text==txtTenSach.Text && lvKho.Items[i].SubItems[3].Text==txtLoaiSach.Text && lvKho.Items[i].SubItems[4].Text==txtTacGia.Text && lvKho.Items[i].SubItems[5].Text==txtGiaBan.Text)
                            {
                                co = false;
                                int oSL = int.Parse(lvKho.Items[i].SubItems[2].Text);
                                oSL += Convert.ToInt32(txtSoLuong.Text);
                                lvKho.Items[i].SubItems[2].Text = oSL.ToString();
                                break;
                            }
                        }
                        if (co)//chưa có thêm mới 
                        {
                            ListViewItem item = lvKho.Items.Add(txtMaSach.Text);
                            item.SubItems.Add(txtTenSach.Text);
                            item.SubItems.Add(txtSoLuong.Text);
                            item.SubItems.Add(txtLoaiSach.Text);
                            item.SubItems.Add(txtTacGia.Text);
                            item.SubItems.Add(txtGiaBan.Text);
                        }
                        XoaThongTin_KhoSach();
                        txtMaSach.Focus();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Sai định dạng giá bán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Sai định dạng số lượng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            if (lvKho.SelectedItems.Count > 0)
            {
                try
                {
                    int soLuong = Convert.ToInt32(txtSoLuong.Text);
                    try
                    {
                        int giaBan = Convert.ToInt32(txtGiaBan.Text);
                        lvKho.SelectedItems[0].SubItems[0].Text = txtMaSach.Text;
                        lvKho.SelectedItems[0].SubItems[1].Text = txtTenSach.Text;
                        lvKho.SelectedItems[0].SubItems[2].Text = txtSoLuong.Text;
                        lvKho.SelectedItems[0].SubItems[3].Text = txtLoaiSach.Text;
                        lvKho.SelectedItems[0].SubItems[4].Text = txtTacGia.Text;
                        lvKho.SelectedItems[0].SubItems[5].Text = txtGiaBan.Text;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Sai định dạng giá bán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {

                    MessageBox.Show("Sai định dạng số lượng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Phải chọn ít nhất một dòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvKho.SelectedItems.Count > 0)
            {
                lvKho.Items.Remove(lvKho.SelectedItems[0]);
                XoaThongTin_KhoSach();
            }
            else
            {
                MessageBox.Show("Phải chọn ít nhất một dòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NhaSach_Load(object sender, EventArgs e)
        {
            ListView_Ban();
            ListView_DoanhThu();
            ListView_Kho();
            ListView_SachBan();
            ListView_TimKiem();
            dtpNgay.Value = DateTime.Today;
            dtpNgay1.Value = DateTime.Today;
        }
        private void lvKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKho.SelectedItems.Count > 0)
            {
                txtMaSach.Text = lvKho.SelectedItems[0].SubItems[0].Text;
                txtTenSach.Text = lvKho.SelectedItems[0].SubItems[1].Text;
                txtSoLuong.Text = lvKho.SelectedItems[0].SubItems[2].Text;
                txtLoaiSach.Text = lvKho.SelectedItems[0].SubItems[3].Text;
                txtTacGia.Text = lvKho.SelectedItems[0].SubItems[4].Text;
                txtGiaBan.Text = lvKho.SelectedItems[0].SubItems[5].Text;
            }
            
        }
        private void NhaSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnBan_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            int thanhTien;
            bool co = true;
            try
            {
                if (txtMaSach1.Text == "" && txtTenSach1.Text == "")
                {
                    throw new Exception("Vui lòng nhập thông tin sách");
                }
                if (txtSoLuong1.Text == "")
                {
                    throw new Exception("Vui lòng nhập số lượng");
                }
                if ((txtSoLuong1.Text != "" && txtMaSach1.Text != "") || (txtSoLuong1.Text != "" && txtTenSach1.Text != ""))
                {
                    int soLuong = int.Parse(txtSoLuong1.Text);
                    for (int i = 0; i < lvKho.Items.Count; i++)
                    {
                        //Nếu sách có trong kho
                        if (lvKho.Items[i].SubItems[0].Text == txtMaSach1.Text || lvKho.Items[i].SubItems[1].Text == txtTenSach1.Text)
                        { 
                            //Kiểm tra sách có còn trong kho không?
                            if (Int32.Parse(lvKho.Items[i].SubItems[2].Text) - Int32.Parse(txtSoLuong1.Text) >= 0)
                            {
                                for (int j = 0; j < lvBan.Items.Count; j++)
                                {
                                    if ((lvBan.Items[j].SubItems[0].Text == txtMaSach1.Text && lvBan.Items[j].SubItems[5].Text == dtpNgay.Text) ||
                                        (lvBan.Items[j].SubItems[1].Text == txtTenSach1.Text && lvBan.Items[j].SubItems[5].Text == dtpNgay.Text))//Nếu lvBan đã có sách bán  --> tăng số lượng --> tính lại thành tiền 
                                    {
                                        co = false;
                                        int oSL = int.Parse(lvBan.Items[j].SubItems[2].Text);
                                        oSL += Convert.ToInt32(txtSoLuong1.Text);
                                        lvBan.Items[j].SubItems[2].Text = oSL.ToString();
                                        thanhTien = oSL * Int32.Parse(lvKho.Items[i].SubItems[5].Text);
                                        lvBan.Items[j].SubItems[4].Text = thanhTien.ToString();
                                        break;
                                    }
                                }
                                if (co)//chưa có thông tin sách bán  --> thêm mới 
                                {
                                    ListViewItem item = lvBan.Items.Add(lvKho.Items[i].SubItems[0].Text);
                                    item.SubItems.Add(lvKho.Items[i].SubItems[1].Text);
                                    item.SubItems.Add(txtSoLuong1.Text);
                                    item.SubItems.Add(lvKho.Items[i].SubItems[5]);
                                    thanhTien = Int32.Parse(txtSoLuong1.Text) * Int32.Parse(lvKho.Items[i].SubItems[5].Text);
                                    item.SubItems.Add(thanhTien.ToString());
                                    item.SubItems.Add(dtpNgay.Text);
                                }
                                // cạp nhật lại số lượgn kho
                                lvKho.Items[i].SubItems[2].Text = (Int32.Parse(lvKho.Items[i].SubItems[2].Text) - Convert.ToInt32(txtSoLuong1.Text)).ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không đủ sách, chỉ còn " + lvKho.Items[i].SubItems[2].Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                           
                        }
                       
                    }
                   
                }
                XoaThongTin_BanSach();
                txtMaSach1.Focus();
                for (int i = 0; i < lvBan.Items.Count; i++)
                {
                    tongTien += Int32.Parse(lvBan.Items[i].SubItems[3].Text);
                }
                txtTongTien.Text = String.Format("{0:N0}",tongTien); 
            }

            catch (FormatException)
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < lvBan.Items.Count; i++)
            {
                ListViewItem item1 = lvSachBan.Items.Add(lvBan.Items[i].SubItems[5].Text);
                item1.SubItems.Add(lvBan.Items[i].SubItems[0].Text);
                item1.SubItems.Add(lvBan.Items[i].SubItems[1].Text);
                item1.SubItems.Add(lvBan.Items[i].SubItems[2].Text);
                item1.SubItems.Add(lvBan.Items[i].SubItems[3].Text);
                item1.SubItems.Add(lvBan.Items[i].SubItems[4].Text);

            }
            lvBan.Items.Clear();
        }
        private void dtpNgay1_ValueChanged(object sender, EventArgs e)
        {
            int tong = 0;
            
            lvDoanhThu.Items.Clear();
            for (int i = 0; i < lvSachBan.Items.Count; i++)
            {
                if (lvSachBan.Items[i].SubItems[0].Text == dtpNgay1.Text)
                {
                    ListViewItem item = lvDoanhThu.Items.Add(lvSachBan.Items[i].SubItems[0].Text);
                    item.SubItems.Add(lvSachBan.Items[i].SubItems[1].Text);
                    item.SubItems.Add(lvSachBan.Items[i].SubItems[2].Text);
                    item.SubItems.Add(lvSachBan.Items[i].SubItems[3].Text);
                    item.SubItems.Add(lvSachBan.Items[i].SubItems[4].Text);
                    item.SubItems.Add(lvSachBan.Items[i].SubItems[5].Text);
                }
            }
            for (int i = 0; i < lvDoanhThu.Items.Count; i++)
            {
                tong += Convert.ToInt32(lvDoanhThu.Items[i].SubItems[5].Text);
            }
            txtDoanhThu.Text = String.Format("{0:N0}",tong);           
        }
        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter;
            string path = @"D:\Kho.txt";
            streamWriter = new StreamWriter(path);
            //streamWriter.WriteLine(String.Format("{0, -10}", lvKho.Columns[0].Text) + "|" +
            //                        String.Format("{0, -50}", lvKho.Columns[1].Text) + "|" +
            //                        String.Format("{0, -10}", lvKho.Columns[2].Text) + "|" +
            //                        String.Format("{0, -30}", lvKho.Columns[3].Text) + "|" +
            //                        String.Format("{0, -30}", lvKho.Columns[4].Text) + "|" +
            //                        String.Format("{0, -10}", lvKho.Columns[5].Text));
            for (int i = 0; i < lvKho.Items.Count; i++)
            {
                streamWriter.WriteLine(String.Format("{0, -10}", lvKho.Items[i].SubItems[0].Text) + "|" +
                                        String.Format("{0, -50}", lvKho.Items[i].SubItems[1].Text) + "|" +
                                        String.Format("{0, -10}", lvKho.Items[i].SubItems[2].Text) + "|" +
                                        String.Format("{0, -30}", lvKho.Items[i].SubItems[3].Text) + "|" +
                                        String.Format("{0, -30}", lvKho.Items[i].SubItems[4].Text) + "|" +
                                        String.Format("{0, -10}", lvKho.Items[i].SubItems[5].Text));
            }
            streamWriter.Close();
            MessageBox.Show("Lưu file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }
        private void btnDocFile_Click(object sender, EventArgs e)
        {
            //string path = @"QuanLyNhaSach\Filetxt\Kho.txt";
            OpenFileDialog myOF = new OpenFileDialog();
            myOF.InitialDirectory = @"D:\Kho.txt";
            myOF.Filter = "Text File (*.txt)|*.txt|all files(*.*)|*.*";
            DialogResult result;
            result = myOF.ShowDialog();
            string chuoi;
            string[] ds;
            lvKho.Items.Clear();
            ListViewItem item = new ListViewItem();
            if (result == DialogResult.OK)
            {
                string fileName = myOF.FileName;
                StreamReader myRD = File.OpenText(fileName);
                while (myRD.Peek() > 0)
                {
                    chuoi = myRD.ReadLine();
                    ds = chuoi.Split('|');
                    ds[0] = ds[0].Trim();
                    ds[1] = ds[1].Trim();
                    ds[2] = ds[2].Trim();
                    ds[3] = ds[3].Trim();
                    ds[4] = ds[4].Trim();
                    ds[5] = ds[5].Trim();
                    item = new ListViewItem(ds);
                    lvKho.Items.Add(item);
                }
                myRD.Close();
            }
        }
        private void radMaSach_Click(object sender, EventArgs e)
        {
            bool found = false;
            txtTimKiem.Focus();
            lvTimKiem.Items.Clear();
            for (int i = 0; i < lvKho.Items.Count; i++)
            {
                if (lvKho.Items[i].SubItems[0].Text.ToLower()==(txtTimKiem.Text.ToLower()))
                {
                    found = true;
                    ListViewItem it = lvTimKiem.Items.Add(lvKho.Items[i].SubItems[0].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[1].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[2].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[5].Text);

                }
            }
            if (found == false)
            {
                MessageBox.Show("Không có thông tin sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.Text = "";
        }
        private void radTenSach_Click(object sender, EventArgs e)
        {
            bool found = false;
            txtTimKiem.Focus();
            lvTimKiem.Items.Clear();
            for (int i = 0; i < lvKho.Items.Count; i++)
            {
                if (lvKho.Items[i].SubItems[1].Text.ToLower()==(txtTimKiem.Text.ToLower()))
                {
                    found = true;
                    ListViewItem it = lvTimKiem.Items.Add(lvKho.Items[i].SubItems[0].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[1].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[2].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[5].Text);
                }
            }
            if (found == false)
            {
                MessageBox.Show("Không có thông tin sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.Text = "";
        }
        private void radLoaiSach_Click(object sender, EventArgs e)
        {
            bool found = false;
            txtTimKiem.Focus();
            lvTimKiem.Items.Clear();
            lvTimKiem.Items.Clear();
            for (int i = 0; i < lvKho.Items.Count; i++)
            {
                if(lvKho.Items[i].SubItems[3].Text.ToLower()==(txtTimKiem.Text.ToLower()))
                {
                    found = true;
                    ListViewItem it = lvTimKiem.Items.Add(lvKho.Items[i].SubItems[0].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[1].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[2].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[5].Text);

                }
            }
            if (found == false)
            {
                MessageBox.Show("Không có thông tin loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.Text = "";
        }
        private void radTacGia_Click(object sender, EventArgs e)
        {
            bool found = false;
            txtTimKiem.Focus();
            lvTimKiem.Items.Clear();
            for (int i = 0; i < lvKho.Items.Count; i++)
            {
                if (lvKho.Items[i].SubItems[5].Text.ToLower()==(txtTimKiem.Text.ToLower()))
                {
                    found = true;
                    ListViewItem it = lvTimKiem.Items.Add(lvKho.Items[i].SubItems[0].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[1].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[2].Text);
                    it.SubItems.Add(lvKho.Items[i].SubItems[5].Text);

                }
            }
            if (found == false)
            {
                MessageBox.Show("Không có thông tin tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.Text = "";
            
        }
    }
}
