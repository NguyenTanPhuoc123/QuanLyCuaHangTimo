﻿using frmLogin.Data_Access_Layer;
using frmLogin.Data_Tranfer_Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLogin
{
    public partial class frmProductManagement : Form
    {
        public frmProductManagement()
        {
            InitializeComponent();
            dtgvListProduct.AutoGenerateColumns = false;
            cbFillProduct.SelectedIndex = 0;
        }

        private void btnProductDeleted_Click(object sender, EventArgs e)
        {
            frmRecycleBin frm = new frmRecycleBin();
            frm.Show();

        }
        Product product;
        public void getValue()
        {
            string maSP = txtProductID.Text;
            string tenSP = txtProductName.Text;
            int donGia = Convert.ToInt32(txtPrice.Text);
            int soLuong = Convert.ToInt32(numQuantity.Value.ToString());
            string moTa = richtxtDescribe.Text;
            int danhMuc = Convert.ToInt32(cbCategory.SelectedValue.ToString());
            byte[] hinhAnh = ConvertImageToByte(pbProduct);
            product = new Product(maSP, tenSP, danhMuc, soLuong, donGia, 1,hinhAnh,moTa);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            getValue();
            string query ="INSERT INTO SANPHAM(MASANPHAM,TENSANPHAM,DANHMUC,SOLUONG,DONGIA,MOTA,TRANGTHAI,HinhANh) VALUES(@MASP,@TENSP,@DANHMUC,@SOLUONG,@DONGIA,@MOTA,@TRANGTHAI,@HINHANH)";
            int count = ProductDAF.ExecuteInsertCommand(query, product);
            MessageBox.Show(count > 0 ? "Them thanh cong" : "Them that bai");
            frmProductManagement_Load(sender, e);
            ResetText();
        }
        public byte[] ConvertImageToByte(PictureBox image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Image.Save(memoryStream,image.Image.RawFormat);
                return memoryStream.ToArray();
            }
        }

        private void pbProduct_Click(object sender, EventArgs e)
        {  
            ofdImage.Filter = "Image files(*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                pbProduct.ImageLocation = ofdImage.FileName;
            }
            
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            dtgvListProduct.DataSource = ProductDAF.Instance.GetListProduct();
            cbCategory.DataSource = CategoryFoodDAF.Instance.GetCategoryFoods();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";
            List<CategoryFood> list = new List<CategoryFood>();
            list = CategoryFoodDAF.Instance.GetCategoryFoods();
            for(int i = 0; i < list.Count; i++)
            {
                cbFillProduct.Items.Add(list[i].CategoryName);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string query = "UPDATE SANPHAM SET TRANGTHAI=0 WHERE MASANPHAM=@SANPHAM";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@SANPHAM", txtProductID.Text);
            int data = ProductDAF.Instance.DeleteProduct(query, parameter);
            MessageBox.Show(data > 0 ? "Xoa thanh cong" : "Xoa that bai");
            frmProductManagement_Load(sender, e);
            ResetText();
        }
        public void ResetText()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            richtxtDescribe.Clear();
            numQuantity.Value = 1;
            cbCategory.SelectedIndex = 0;
            pbProduct.Image = null;
        }
        //...
    }
}
