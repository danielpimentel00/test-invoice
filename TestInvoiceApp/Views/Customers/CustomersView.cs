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
        private readonly CustomersPresenter _customersPresenter;
        public CustomersView()
        {
            InitializeComponent();
            _customersPresenter = new CustomersPresenter(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var createCustomerView = new CreateCustomerPopup())
            {
                var customersPresenter = new CustomersPresenter(createCustomerView);

                createCustomerView.FormClosed += (s, args) =>
                {
                    if (createCustomerView.DialogResult == DialogResult.OK)
                    {
                        _customersPresenter.RefreshDataGrid();
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = value ? "Activo" : "Inactivo";
                    e.FormattingApplied = true;
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    int customerTypeId = Convert.ToInt32(e.Value);
                    var customerType = _customersPresenter.GetCustomerTypes().FirstOrDefault(ct => ct.Id == customerTypeId);

                    if (customerType != null)
                    {
                        e.Value = customerType.Description;
                        e.FormattingApplied = true; // Marca como formateado
                    }
                }
            }
        }
    }
}
