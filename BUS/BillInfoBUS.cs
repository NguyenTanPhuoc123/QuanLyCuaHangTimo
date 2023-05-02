﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BillInfoBUS
    {
        private static BillInfoBUS instance;
        public static BillInfoBUS Instance
        {
            get { if (instance == null) instance = new BillInfoBUS(); return BillInfoBUS.instance; }
            private set { BillInfoBUS.instance = value; }
        }

        private BillInfoBUS()
        {

        }

        public List<BillInfo> GetListBill()
        {
            return BillInfoDAO.Instance.GetListBillInfo();
        }

        public int InsertNewBillInfo(string billID, string productID, float price, string count, float total)
        {
            return BillInfoDAO.Instance.InsertNewBillInfo(billID, productID, price,count, total);
        }


        public int DeleteBillInfo(string billID, string productID)
        {
            return BillInfoDAO.Instance.DeleteBillInfo(billID, productID);
        }

        public int DeleteAllBillInfo()
        {
            return BillInfoDAO.Instance.DeleteAllBillInfo();
        }


        public void ADDBILLINFO(string masp, string soluong)
        {
            BillInfoDAO.Instance.ADDBILLINFO(masp, soluong);
        }

    }
}