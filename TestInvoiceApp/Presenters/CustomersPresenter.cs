using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInvoiceApp.Models;
using TestInvoiceApp.Views;
using TestInvoiceApp.Views.Customers;

namespace TestInvoiceApp.Presenters
{
    public class CustomersPresenter
    {
        private readonly CustomersModel _customersModel;
        
        public CustomersPresenter()
        {
            _customersModel = new CustomersModel();
        }

        public void InitializeCustomersView(CustomersView view)
        {
            var data = _customersModel.GetCustomers();

            view.dataGridView1.AutoGenerateColumns = false;
            view.dataGridView1.DataSource = data;

            //view.dataGridView1.Columns.Add("CustName", "Nombre");
            //view.dataGridView1.Columns.Add("Adress", "Dirección");
            //view.dataGridView1.Columns.Add("Status", "Estatus");
            //view.dataGridView1.Columns.Add("CustomerTypeId", "Tipo de Cliente");

            //view.dataGridView1.Columns["Id"].DataPropertyName = "Id";
            //view.dataGridView1.Columns["CustName"].DataPropertyName = "CustName";
            //view.dataGridView1.Columns["Adress"].DataPropertyName = "Adress";
            //view.dataGridView1.Columns["Status"].DataPropertyName = "Status";
            //view.dataGridView1.Columns["CustomerTypeId"].DataPropertyName = "CustomerTypeId";

            view.Show();
        }
    }
}
