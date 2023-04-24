﻿
using System;
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
using System.IO;

namespace frmLogin
{
    public partial class frmRecycleBin : Form
    {
        public frmRecycleBin()
        {
            InitializeComponent();
        }

        private void frmRecycleBin_Load(object sender, EventArgs e)
        {
            LoadAccountDeleted();
            LoadTableFoodDeleted();
        }

        private void btnExitFormSelectDish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region TableFood 
        void LoadTableFoodDeleted()
        {
            dtgvListTableFoodDeleted.DataSource = TableMenuBUS.Instance.GetListTableMenuDeleted();
        }

        private void dtgvListTableFoodDeleted_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvListTableFoodDeleted.SelectedRows.Count > 0)
            {
                txtTableID.Text = dtgvListTableFoodDeleted.SelectedRows[0].Cells[0].Value.ToString();
                txtTableName.Text = dtgvListTableFoodDeleted.SelectedRows[0].Cells[1].Value.ToString();
                txtLocation.Text = dtgvListTableFoodDeleted.SelectedRows[0].Cells[4].Value.ToString();

            }
        }

        private void btnRestoreTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn khôi phục lại bàn ăn này chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int count = TableBUS.Instance.RestoreTable(int.Parse(txtTableID.Text));
                    if (count > 0)
                        MessageBox.Show("Khôi phục thành công ", "Khôi phục bàn ăn", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Khôi phục thất bại ", "Khôi phục bàn ăn", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadTableFoodDeleted();
            }
        }

        private void btnRestoreAllTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn khôi phục lại tất cả bàn ăn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int count = TableBUS.Instance.RestoreAllTable();
                    if (count > 0)
                        MessageBox.Show("Khôi phục tất cả thành công ", "Khôi phục bàn ăn", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Khôi phục tất cả thất bại ", "Khôi phục bàn ăn", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadTableFoodDeleted();
            }
        }
        #endregion
       

        #region Account
        private void btnRestoreAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn phục hồi lại tài khoản này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int count = AccountBUS.Instance.RestoreAccountByUserName(txtUsername.Text);
                if (count > 0)
                    MessageBox.Show("Khôi phục thành công", "Khôi phục tài khoản", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Khôi phục thất bại", "Khôi phục tài khoản", MessageBoxButtons.OK);
            }
            frmRecycleBin_Load(sender, e);

        }

        private void btnRestoreAllAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn phục hồi lại tất cả tài khoản này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int count = AccountBUS.Instance.RestoreAllAccount();
                if (count > 0)
                    MessageBox.Show("Khôi phục thành công", "Khôi phục tài khoản", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Khôi phục thất bại", "Khôi phục tài khoản", MessageBoxButtons.OK);
            }
        }

        public void LoadAccountDeleted()
        {
            dtgvListAccountDeleted.DataSource = AccountBUS.Instance.GetListAccountDeleted();
        }

        private void dtgvListAccountDeleted_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dtgvListAccountDeleted.SelectedRows[0].Cells[0].Value.ToString();
            txtPassword.Text = dtgvListAccountDeleted.SelectedRows[0].Cells[1].Value.ToString();
            txtEmployee.Text = dtgvListAccountDeleted.SelectedRows[0].Cells[2].Value.ToString();
            int type = int.Parse(dtgvListAccountDeleted.SelectedRows[0].Cells[3].Value.ToString());
            if (type == 1)
                txtTypeAccount.Text = "Nhân viên quản lý";
            else
                txtTypeAccount.Text = "Nhân viên bán hàng";

        }
        #endregion

        #region Product
        private void LoadProductDeleted()
        {
            dtgvListProductDeleted.DataSource = ProductBUS.Instance.GetListProductDeleted();
        }
        private void dtgvListProductDeleted_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i == -1) return;
            MemoryStream memoryStream = new MemoryStream((byte[])dtgvListProductDeleted.Rows[i].Cells[0].Value);
            pbProduct.Image = Image.FromStream(memoryStream);
            txtProductID.Text = dtgvListProductDeleted.Rows[i].Cells[1].Value.ToString();
            txtProductName.Text = dtgvListProductDeleted.Rows[i].Cells[2].Value.ToString();
            cbCategory.SelectedValue = dtgvListProductDeleted.Rows[i].Cells[4].Value;
            numQuantity.Value = Convert.ToInt32(dtgvListProductDeleted.Rows[i].Cells[5].Value);
            txtPrice.Text = dtgvListProductDeleted.Rows[i].Cells[6].Value.ToString();
            richtxtDescribe.Text = dtgvListProductDeleted.Rows[i].Cells[7].Value.ToString();
        }
        private void btnRestoreProduct_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Ban co muon khoi phuc san pham", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int cout = ProductBUS.Instance.RestoreProduct(txtProductID.Text);
                MessageBox.Show(cout > 0 ? "Khoi phuc thanh cong" : "Khoi phuc that bai");
            }
        }
        private void btnRestoreAllProduct_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Ban co muon khoi phuc tat ca san pham", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int cout = ProductBUS.Instance.RestoreProductAll();
                MessageBox.Show(cout > 0 ? "Khoi phuc thanh cong" : "Khoi phuc that bai");
            }
        }
        #endregion

    }
}
