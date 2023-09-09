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

namespace TestInvoiceApp.Views.Invoice
{
    public partial class CreateInvoicePopup : Form
    {
        private readonly List<InvoiceDetailModelArgs> _invoiceDetailList = new List<InvoiceDetailModelArgs>();
        public CreateInvoicePopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int quantity = (int)qty_numericUpDown.Value;
            decimal price = price_numericUpDown.Value;
            var selectedCustomer = (Customer)customer_comboBox.SelectedItem;

            if (selectedCustomer == null)
            {
                MessageBox.Show("Por favor, selecciona un cliente.", "Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int customerId = selectedCustomer.Id;

            // Validar que la cantidad sea mayor que cero
            if (quantity <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Cantidad no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el precio sea mayor que cero
            if (price <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero.", "Precio no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _invoiceDetailList.Add(new InvoiceDetailModelArgs
            {
                CustomerId = customerId,
                Quantity = quantity,
                Price = price,
            });

            qty_numericUpDown.Value = 0;
            price_numericUpDown.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var invoicePresenter = new InvoicePresenter(this);
            invoicePresenter.CreateInvoiceDetail(_invoiceDetailList);
        }
    }
}
