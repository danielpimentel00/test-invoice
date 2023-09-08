using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInvoiceApp.Presenters;

namespace TestInvoiceApp.Views.Customers
{
    public partial class CreateCustomerPopup : Form
    {
        public CreateCustomerPopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var customersPresenter = new CustomersPresenter(this);
            customersPresenter.CreateCustomer();
        }
    }
}
