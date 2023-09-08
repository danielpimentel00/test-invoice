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

namespace TestInvoiceApp.Views
{
    public partial class CustomerTypesView : Form
    {
        private readonly CustomerTypesPresenter _customerTypesPresenter = new CustomerTypesPresenter();

        public CustomerTypesView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var popupForm = new CreateCustomerTypePopup())
            {
                if (popupForm.ShowDialog() == DialogResult.OK)
                {
                    string nuevoRegistro = popupForm.textBox1.Text;

                    _customerTypesPresenter.CreateCustomerType(nuevoRegistro, this);
                    popupForm.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un registro para eliminar.");
                return;
            }

            var item = listBox1.SelectedItem as CustomerType;
            _customerTypesPresenter.RemoveCustomerType(item, this);
        }
    }
}
