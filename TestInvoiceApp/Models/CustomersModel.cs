using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvoiceApp.Models
{
    public class CustomersModel
    {
        private readonly Test_InvoiceEntities _context;

        public CustomersModel()
        {
            _context = new Test_InvoiceEntities();
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                var list = _context.Customers.ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
