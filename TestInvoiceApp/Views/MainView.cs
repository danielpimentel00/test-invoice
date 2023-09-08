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

namespace TestInvoiceApp.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var customerTypesPresenter = new CustomerTypesPresenter();
            var tipoEmpleadoView = new CustomerTypesView();
            customerTypesPresenter.InitializeCustomerTypesView(tipoEmpleadoView);
        }
    }
}
