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
        public Form1()
        {
            InitializeComponent();
        }
        public void activeDataSQL()
        {
            DataTable dtgv = onewaycls.selectData("HANGHOA");
            DataTable dtnv = onewaycls.selectData("NHANVIEN");
            DataTable dt = onewaycls.queryAdapFree("SELECT TOP 1 SODONHANG, (KHACHHANG.MAKH + ' - ' + TENKH) AS FULLTENKH, NOIGIAOHANG, THOIGIANGIAO, GHICHU FROM DONHANG "
            +"INNER JOIN KHACHHANG ON KHACHHANG.MAKH = DONHANG.MAKH WHERE KHACHHANG.MAKH = 'KH0080'");
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox || ctr is ComboBox)
                {
                    ctr.DataBindings.Clear();
                }
            }
            txt_sodonhang.DataBindings.Add("Text", dt, "SODONHANG");
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
            //MessageBox.Show(checkDupli(mh).ToString());
            if (checkDupli(mh) != -1)
            {
                dataGV_cthd.Rows[checkDupli(mh)].Cells["SL"].Value =
                    Convert.ToInt32(dataGV_cthd.Rows[checkDupli(mh)].Cells["SL"].Value) + sl;
                if (Convert.ToInt32(dataGV_cthd.Rows[checkDupli(mh)].Cells["SL"].Value) >= 100)
                {
                    dataGV_cthd.Rows[checkDupli(mh)].Cells["DonGia"].Value = dataGV.CurrentRow.Cells["GiaBanBuon"].Value;
                }
            }
            else
            {
                dataGV_cthd.Rows.Add(mh, th, sl, dongia, nup_ck.Value, nup_tongcong.Value);
            }
          
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
        public void group_box_tongcong()
        {
            decimal tienhang = 0;
            decimal thue = Convert.ToInt16(nup_valthue.Value);
            decimal chiet_khau = nup_valck.Value;
            decimal Tong_cong = 0;
            for (int i = 0; i < dataGV_cthd.RowCount - 1; i++)
            {
                tienhang = tienhang + Convert.ToDecimal(dataGV_cthd.Rows[i].Cells["ThanhTien"].Value);
            }
            MessageBox.Show(tienhang.ToString());
            thue = (nup_valthue.Value / 100) * tienhang;
            chiet_khau = (this.nup_valck.Value / 100) * tienhang;
            Tong_cong = tienhang + thue - chiet_khau;
            //nup_tienhang.Text = tienhang.ToString();
            //nup_tongcong.Text = Tong_cong.ToString();
            //nup_thue.Text = thue.ToString();
            //nup_ck.Text = chiet_khau.ToString();
            nup_thue.Value = thue;
            MessageBox.Show(thue.ToString());
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

        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            group_box_tongcong();
        }
    }
}
