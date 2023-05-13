﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace frmLogin
{
    public partial class frmPay : Form
    {
        public frmPay()
        {
            InitializeComponent();
        }
        
        private void btnExitFomPay_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int TableID = frmSellManagement.GetTableID();
        string BillID = BillBUS.Instance.HDID(frmSellManagement.GetTableID());
        int EmployeeID = frmSellManagement.GetMANV();
        float Total = frmSellManagement.GetTotal();
        string EmployeeName = frmSellManagement.GetTENNV();

        private void txtMoneyPay_TextChanged(object sender, EventArgs e)
        {
            lblMoneyReceive.Text = txtMoneyPay.Text;
            //lblMoneyPay.Text = (Convert.ToInt32(lblMoneyReceive.Text) - Convert.ToInt32(lblTotal.Text)).ToString();
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            txtBillID.Text = BillID.ToString();
            txtEmployeeID.Text = EmployeeID.ToString();
            txtEmployeeName.Text = EmployeeName;
            txtCheckIn.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lblTotal.Text = Total.ToString();
            dtgvBill.DataSource = BillInfoMenuBUS.Instance.GetListBillInfoMenu(BillID);
            LoadDiscount();
        }

        public void LoadDiscount()
        {
            cbDiscount.DataSource = DiscountBUS.Instance.GetListDiscountAvailable();
            cbDiscount.DisplayMember = "DiscountName";
            cbDiscount.ValueMember = "DiscountID";

        }

        private void btnOutputBill_Click(object sender, EventArgs e)
        {
            int row = TableBUS.Instance.UpdateTablePay(TableID);
            int count = BillBUS.Instance.OutputBill(txtBillID.Text, Total);
            if (count > 0 && row > 0)
            {
                MessageBox.Show("Thanh toán thành công");
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại");
            }
            frmPay_Load(sender, e);
        }

        private void cbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = cbDiscount.SelectedValue.ToString();
            
            lblMoneyPay.Text = DiscountBUS.Instance.GetDiscountForID(ID).Price.ToString();
            //Total = Total - float.Parse(discount.Price.ToString());
            
        }
    }
}
