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
    public partial class CustomersView : Form
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var createCustomerView = new CreateCustomerPopup())
            {
                var customersPresenter = new CustomersPresenter(createCustomerView);
                customersPresenter.InitializeCreateCustomerForm();

                //if (createCustomerView.ShowDialog() == DialogResult.OK)
                //{
                //    //string nuevoRegistro = createCustomerView.textBox1.Text;
                //    createCustomerView.Close();
                //}
            }
        }
    }
}
