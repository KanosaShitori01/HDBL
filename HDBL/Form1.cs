using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLSB;
namespace HDBL
{
    public partial class Form1 : Form
    {
        public DataTable dtgv = onewaycls.selectData("HANGHOA");
        public DataTable dtnv = onewaycls.selectData("NHANVIEN");
        public DataTable dt = onewaycls.queryAdapFree("SELECT TOP 1 SODONHANG, SOTIEN, CHIETKHAU, KHACHHANG.MAKH, (KHACHHANG.MAKH + ' - ' + TENKH) AS FULLTENKH, NOIGIAOHANG, THOIGIANGIAO, GHICHU FROM DONHANG "
        + "INNER JOIN KHACHHANG ON KHACHHANG.MAKH = DONHANG.MAKH WHERE KHACHHANG.MAKH = 'KH0080'");
        public Form1()
        {
            InitializeComponent();
        }
        public int reachMH(string mah)
        {
            string newID = "";
            DataTable table = onewaycls.queryAdapFree(
                String.Format("SELECT * FROM DONHANG WHERE SODONHANG LIKE '%{0}%'", mah.Substring(0, mah.Length - 3)));
            if (table.Rows.Count > 0)
            {
                int length = table.Rows.Count;
                newID += length;
            }
            else return 1;
            return Convert.ToInt32(newID) + 1;
        }
        public void clearAll()
        {
            txt_khachhang.DataBindings.Clear();
            txt_noigiaohang.DataBindings.Clear();
            txt_thoigiangiao.DataBindings.Clear();
            txt_ghichu.DataBindings.Clear();
        }
        public void activeDataSQL()
        {
            clearAll();
            string mahangsieudang = cls_xauchuoi.mahang_sieudang("HDL", dtp_ngay.Text);
            mahangsieudang = cls_xauchuoi.mahang_sieudang("HDL", dtp_ngay.Text, reachMH(mahangsieudang));
            txt_sodonhang.Text = mahangsieudang;
            txt_khachhang.DataBindings.Add("Text", dt, "FULLTENKH");
            txt_noigiaohang.DataBindings.Add("Text", dt, "NOIGIAOHANG");
            txt_thoigiangiao.DataBindings.Add("Text", dt, "THOIGIANGIAO");
            txt_ghichu.DataBindings.Add("Text", dt, "GHICHU");
            cb_nvkd.DataSource = dtnv;
            cb_nvkd.DisplayMember = "TENNV";
            cb_nvkd.ValueMember = "MANV";
            dataGV.DataSource = dtgv;
        }
        public void addGVCT()
        {
            string mh = dataGV.CurrentRow.Cells["MaHang"].Value.ToString();
            string th = dataGV.CurrentRow.Cells["TenHang"].Value.ToString();
            int sl = Convert.ToInt32(nup_soluong.Value);
            double dongia = Convert.ToDouble(dataGV.CurrentRow.Cells[(sl >= 100) ? "GiaBanBuon" : "GiaBanLe"].Value);
            double thanhtien = sl * dongia;
            //MessageBox.Show(checkDupli(mh).ToString());
            if (checkDupli(mh) != -1)
            {
                DataGridViewRow gridView = dataGV_cthd.Rows[checkDupli(mh)];
                DataGridViewRow gridView2 = dataGV.Rows[checkDupli(mh)];
                gridView.Cells["SL"].Value = Convert.ToInt32(gridView.Cells["SL"].Value) + sl;
                gridView.Cells["ThanhTien"].Value = Convert.ToInt32(gridView.Cells["SL"].Value) * dongia;
                if (Convert.ToInt32(gridView.Cells["SL"].Value) >= 100)
                {
                    gridView.Cells["DonGia"].Value = gridView2.Cells["GiaBanBuon"].Value;
                }
            }
            else
            {
                dataGV_cthd.Rows.Add(mh, th, sl, dongia, dt.Rows[0]["CHIETKHAU"], thanhtien);
            }
            SumAll();
        }
        public int checkDupli(string id)
        {
            int flag = -1;
            for (int i = 0; i < dataGV_cthd.RowCount - 1; i++)
            {
                if (id == dataGV_cthd.Rows[i].Cells["MaHang_2"].Value.ToString())
                {
                    flag = i;
                }
            }
            return flag;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            activeDataSQL();
        }
        public decimal SumAll()
        {
            decimal tienhang = 0;
            decimal thue = Convert.ToInt16(nup_valthue.Value);
            decimal chiet_khau = nup_valck.Value;
            decimal Tong_cong = 0;
            for (int i = 0; i < dataGV_cthd.RowCount - 1; i++)
            {
                tienhang = tienhang + Convert.ToDecimal(dataGV_cthd.Rows[i].Cells["ThanhTien"].Value);
            }
            thue = (nup_valthue.Value / 100) * tienhang;
            chiet_khau = (this.nup_valck.Value / 100) * tienhang;
            Tong_cong = tienhang + thue - chiet_khau;
            txt_tienhang.Text = tienhang.ToString();
            txt_thue.Text = thue.ToString();
            txt_ck.Text = chiet_khau.ToString();
            return Tong_cong;
        }

        private void nup_tienhang_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            addGVCT();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void nup_soluong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nup_valthue_ValueChanged(object sender, EventArgs e)
        {
            txt_thue.Text = ((nup_valthue.Value / 100) * Convert.ToInt32(txt_tienhang.Text)).ToString();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            //SumAll();
            txt_tongcong.Text = SumAll().ToString();
            btn_ghidulieu.Enabled = true;
        }

        private void nup_valck_ValueChanged(object sender, EventArgs e)
        {
            txt_ck.Text = ((nup_valck.Value / 100) * Convert.ToInt32(txt_tienhang.Text)).ToString();
        }

        private void btn_ghidulieu_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> valuePairs = new Dictionary<string, object>();
            valuePairs.Add("SODONHANG", "'"+txt_sodonhang.Text+"'");
            valuePairs.Add("MAKH", "'"+dt.Rows[0]["MaKH"]+"'");
            valuePairs.Add("NGAYLAP", "'" + dtp_ngay.Text + "'");
            valuePairs.Add("NOIGIAOHANG", "'" + txt_noigiaohang.Text + "'");
            valuePairs.Add("THOIGIANGIAO", "'" + dtp_ngay.Text + "'");
            valuePairs.Add("THUE", txt_thue.Text);
            valuePairs.Add("CHIETKHAU", txt_ck.Text);
            valuePairs.Add("SOTIEN", txt_tongcong.Text);
            string result = onewaycls.insertData("DONHANG", valuePairs);
            for(int i = 0; i < dataGV_cthd.RowCount - 1; i++)
            {
                Dictionary<string, object> valPairs = new Dictionary<string, object>();
                valPairs.Add("SODONHANG", valuePairs["SODONHANG"]);
                valPairs.Add("MAHANG", "'" + dataGV_cthd.Rows[i].Cells["MaHang_2"].Value + "'");
                valPairs.Add("SOLUONG", dataGV_cthd.Rows[i].Cells["SL"].Value);
                //MessageBox.Show(onewaycls.insertData("CHITIETDONHANG", valPairs));   
            }
            MessageBox.Show(result);
            btn_inhoadon.Enabled = true;
            activeDataSQL();
        }

        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            
        }
    }
}
