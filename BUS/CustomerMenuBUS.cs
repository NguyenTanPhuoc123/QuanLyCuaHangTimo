﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CustomerMenuBUS
    {
        private static CustomerMenuBUS instance;
 
        public static CustomerMenuBUS Instance
        {
            get { if (instance == null) instance = new CustomerMenuBUS(); return CustomerMenuBUS.instance; }
            private set { CustomerMenuBUS.instance = value; }
        }

        private CustomerMenuBUS()
        {

        }

        public List<CustomerMenu> GetListCustomerMenu()
        {
            return CustomerMenuDAO.Instance.GetListCustomerMenu();
        }

        public List<CustomerMenu> GetListCustomerMenuDeleted()
        {
            return CustomerMenuDAO.Instance.GetListCustomerMenuDeleted();
        }

        public List<CustomerMenu> SearchCustomerByName(string name)
        {
            return CustomerMenuDAO.Instance.SearchCustomerByName(name);
        }

        public List<CustomerMenu> SortCustomerByID()
        {
            return CustomerMenuDAO.Instance.SortCustomerByID();
        }

        public List<CustomerMenu> SortCustomerByIDDecrease()
        {
            return CustomerMenuDAO.Instance.SortCustomerByIDDecrease();
        }

        public List<CustomerMenu> SortCustomerByName()
        {
            return CustomerMenuDAO.Instance.SortCustomerByName();
        }

        public List<CustomerMenu> SortCustomerByNameDecrease()
        {
            return CustomerMenuDAO.Instance.SortCustomerByNameDecrease();
        }


    }
}
