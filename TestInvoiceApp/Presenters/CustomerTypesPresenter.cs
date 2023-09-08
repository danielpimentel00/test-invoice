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
        private readonly TipoEmpleadoView _customerTypeView;
        private readonly CustomerTypesModel _customerTypeModel;
        public CustomerTypesPresenter()
        {
            _customerTypeView = new TipoEmpleadoView();
            _customerTypeModel = new CustomerTypesModel();
        }
        public void InitializeCustomerTypesView()
        {
            var data = _customerTypeModel.GetCustomerTypes();
            _customerTypeView.listBox1.DataSource = data;
            _customerTypeView.listBox1.DisplayMember = "Description";
            _customerTypeView.Refresh();
            _customerTypeView.Show();
        }
    }
}
