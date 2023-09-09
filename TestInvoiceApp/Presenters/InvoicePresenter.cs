using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInvoiceApp.Models;
using TestInvoiceApp.Views.Customers;
using TestInvoiceApp.Views.Invoice;

namespace TestInvoiceApp.Presenters
{
    public class InvoicePresenter
    {
        private readonly CreateInvoicePopup _createInvoiceView;
        private readonly InvoiceView _invoiceView;
        private readonly CustomersModel _customersModel = new CustomersModel();
        private readonly InvoiceModel _invoiceModel = new InvoiceModel();

        public InvoicePresenter(CreateInvoicePopup createInvoiceView)
        {
            _createInvoiceView = createInvoiceView;
        }

        public InvoicePresenter(InvoiceView invoiceView)
        {
            _invoiceView = invoiceView;
        }

        public void InitializeInvoiceView()
        {
            var data = _invoiceModel.GetInvoices();
            _invoiceView.dataGridView1.AutoGenerateColumns = false;
            _invoiceView.dataGridView1.DataSource = data;
            _invoiceView.Show();
        }

        public void InitializeCreateInvoiceForm()
        {
            var data = _customersModel.GetCustomers();
            _createInvoiceView.customer_comboBox.DataSource = data;
            _createInvoiceView.customer_comboBox.DisplayMember = "CustName";
            _createInvoiceView.customer_comboBox.Refresh();
            _createInvoiceView.ShowDialog();
        }

        public List<Customer> GetCustomers()
        {
            return _customersModel.GetCustomers();
        }

        public void RefreshDataGrid()
        {
            var updatedData = _invoiceModel.GetInvoices();
            _invoiceView.dataGridView1.AutoGenerateColumns = false;
            _invoiceView.dataGridView1.DataSource = updatedData;
        }

        public void CreateInvoiceDetail(List<InvoiceDetailModelArgs> invoiceDetailList)
        {
            _invoiceModel.CreateInvoiceWithDetails(invoiceDetailList);
            _createInvoiceView.Close();
        }
    }
}
