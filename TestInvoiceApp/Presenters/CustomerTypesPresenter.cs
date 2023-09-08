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
        private readonly CustomerTypesModel _customerTypeModel;

        public CustomerTypesPresenter()
        {
            _customerTypeModel = new CustomerTypesModel();
        }

        public void InitializeCustomerTypesView(TipoEmpleadoView view)
        {
            var data = _customerTypeModel.GetCustomerTypes();
            view.listBox1.DataSource = data;
            view.listBox1.DisplayMember = "Description";
            view.Refresh();
            view.Show();
        }

        public void CreateCustomerType(string description, TipoEmpleadoView view)
        {
            _customerTypeModel.AddCustomerType(description);

            var updatedData = _customerTypeModel.GetCustomerTypes();
            view.listBox1.DataSource = updatedData;
            view.listBox1.DisplayMember = "Description";
            view.Refresh();
        }

        public void RemoveCustomerType(CustomerType model, TipoEmpleadoView view)
        {
            _customerTypeModel.RemoveCustomerType(model);

            var updatedData = _customerTypeModel.GetCustomerTypes();
            view.listBox1.DataSource = updatedData;
            view.listBox1.DisplayMember = "Description";
            view.Refresh();
        }
    }
}
