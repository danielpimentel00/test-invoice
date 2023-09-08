using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInvoiceApp.Models;
using TestInvoiceApp.Views;

namespace TestInvoiceApp.Presenters
{
    public class CustomerTypesPresenter
    {
        private readonly CustomerTypesModel _customerTypesModel;

        public CustomerTypesPresenter()
        {
            _customerTypesModel = new CustomerTypesModel();
        }

        public void InitializeCustomerTypesView(CustomerTypesView view)
        {
            var data = _customerTypesModel.GetCustomerTypes();
            view.listBox1.DataSource = data;
            view.listBox1.DisplayMember = "Description";
            view.Refresh();
            view.Show();
        }

        public void CreateCustomerType(string description, CustomerTypesView view)
        {
            _customerTypesModel.AddCustomerType(description);

            var updatedData = _customerTypesModel.GetCustomerTypes();
            view.listBox1.DataSource = updatedData;
            view.listBox1.DisplayMember = "Description";
            view.Refresh();
        }

        public void RemoveCustomerType(CustomerType model, CustomerTypesView view)
        {
            _customerTypesModel.RemoveCustomerType(model);

            var updatedData = _customerTypesModel.GetCustomerTypes();
            view.listBox1.DataSource = updatedData;
            view.listBox1.DisplayMember = "Description";
            view.Refresh();
        }
    }
}
