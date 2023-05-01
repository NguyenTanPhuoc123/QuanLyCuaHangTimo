﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class SizeProductBUS
    {
        private static SizeProductBUS instance;
        public static SizeProductBUS Instance
        {
            get { if (instance == null) instance = new SizeProductBUS(); return SizeProductBUS.instance; }
            private set { SizeProductBUS.instance = value; }
        }

        private SizeProductBUS()
        {

        }

        public List<SizeProduct> GetListSizeProduct()
        {
            return SizeProductDAO.Instance.GetListSizeProduct();
        }

        public List<SizeProduct> GetListSizeProductDeleted()
        {
            return SizeProductDAO.Instance.GetListSizeProductDeleted();
        }

        public List<SizeProduct> GetSizeProduct()
        {
            return SizeProductDAO.Instance.GetSizeProduct();
        }

        public int AddSizeProduct(string sizeName, float sizePrice)
        {
            return SizeProductDAO.Instance.AddSizeProduct(sizeName, sizePrice);
        }

        public int EditSizeProduct(int sizeID, string sizeName, float sizePrice)
        {
            return SizeProductDAO.Instance.EditSizeProduct(sizeID, sizeName, sizePrice);
        }

        public int DeleteSizeProduct(int sizeID)
        {
            return SizeProductDAO.Instance.DeleteSizeProduct(sizeID);
        }

        public int DeleteAllSizeProduct()
        {
            return SizeProductDAO.Instance.DeleteAllSizeProduct();
        }

        public int RestoreSizeProduct(int sizeID)
        {
            return SizeProductDAO.Instance.RestoreSizeProduct(sizeID);
        }

        public int RestoreAllSizeProduct()
        {
            return SizeProductDAO.Instance.RestoreAllSizeProduct();
        }
    }
}
