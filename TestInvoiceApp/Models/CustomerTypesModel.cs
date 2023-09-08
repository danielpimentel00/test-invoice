﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestInvoiceApp.Models
{
    public class CustomerTypesModel
    {
		private readonly Test_InvoiceEntities _context;

        public CustomerTypesModel()
		{
			_context = new Test_InvoiceEntities();
		}

        public List<CustomerType> GetCustomerTypes() {
			try
			{
				var list = _context.CustomerTypes.ToList();
				return list;
            }
			catch (Exception)
			{
				throw;
			}
        }

		public void AddCustomerType(string description)
		{
			try
			{
				_context.CustomerTypes.Add(new CustomerType
				{
					Description = description
				});
				_context.SaveChanges();
			}
			catch (Exception)
			{ 
				throw;
			}
		}

		public void RemoveCustomerType(CustomerType model)
		{
			try
			{
				_context.CustomerTypes.Remove(model);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw;
			}
		}
    }
}