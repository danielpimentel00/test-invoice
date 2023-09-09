using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInvoiceApp.Models;
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
                var customersPresenter2 = new CustomersPresenter(this);

                createCustomerView.FormClosed += (s, args) =>
                {
                    if (createCustomerView.DialogResult == DialogResult.OK)
                    {
                        customersPresenter2.RefreshDataGrid();
                    }
                };

                customersPresenter.InitializeCreateCustomerForm();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var customersPresenter = new CustomersPresenter(this);

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un registro para eliminar.");
                return;
            }

            var selectedRows = dataGridView1.SelectedRows;
            var selectedCustomers = new List<Customer>();

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row.DataBoundItem is Customer customer)
                {
                    selectedCustomers.Add(customer);
                }
            }

            customersPresenter.RemoveCustomers(selectedCustomers);
        }
    }
}
