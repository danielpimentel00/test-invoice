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
using TestInvoiceApp.Views.Customers;

namespace TestInvoiceApp.Views.Invoice
{
    public partial class InvoiceView : Form
    {
        private readonly InvoicePresenter _invoicePresenter;

        public InvoiceView()
        {
            InitializeComponent();
            _invoicePresenter = new InvoicePresenter(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var createInvoiceView = new CreateInvoicePopup())
            {
                var invoicePresenter = new InvoicePresenter(createInvoiceView);
                var invoicePresenter2 = new InvoicePresenter(this);

                createInvoiceView.FormClosed += (s, args) =>
                {
                     invoicePresenter2.RefreshDataGrid();
                };

                invoicePresenter.InitializeCreateInvoiceForm();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    int customerId = Convert.ToInt32(e.Value);
                    var customer = _invoicePresenter.GetCustomers().FirstOrDefault(ct => ct.Id == customerId);

                    if (customer != null)
                    {
                        e.Value = customer.CustName;
                        e.FormattingApplied = true; // Marca como formateado
                    }
                }
            }
        }
    }
}
