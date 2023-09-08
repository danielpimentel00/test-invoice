﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInvoiceApp.Models;
using TestInvoiceApp.Views;
using TestInvoiceApp.Views.Customers;

namespace TestInvoiceApp.Presenters
{
    public class CustomersPresenter
    {
        private readonly CustomersModel _customersModel = new CustomersModel();
        private readonly CustomersView _customersView;
        private readonly CreateCustomerPopup _createCustomerView;
        private readonly CustomerTypesModel _customerTypesModel = new CustomerTypesModel();

        public CustomersPresenter(CustomersView customersView)
        {
            _customersView = customersView;
        }

        public CustomersPresenter(CreateCustomerPopup createCustomerView)
        {
            _createCustomerView = createCustomerView;
        }

        public void InitializeCustomersView()
        {
            var data = _customersModel.GetCustomers();

            _customersView.dataGridView1.AutoGenerateColumns = false;
            _customersView.dataGridView1.DataSource = data;

            //view.dataGridView1.Columns.Add("CustName", "Nombre");
            //view.dataGridView1.Columns.Add("Adress", "Dirección");
            //view.dataGridView1.Columns.Add("Status", "Estatus");
            //view.dataGridView1.Columns.Add("CustomerTypeId", "Tipo de Cliente");

            //view.dataGridView1.Columns["Id"].DataPropertyName = "Id";
            //view.dataGridView1.Columns["CustName"].DataPropertyName = "CustName";
            //view.dataGridView1.Columns["Adress"].DataPropertyName = "Adress";
            //view.dataGridView1.Columns["Status"].DataPropertyName = "Status";
            //view.dataGridView1.Columns["CustomerTypeId"].DataPropertyName = "CustomerTypeId";

            _customersView.Show();
        }

        public void InitializeCreateCustomerForm()
        {
            var data = _customerTypesModel.GetCustomerTypes();
            _createCustomerView.customerType_comboBox.DataSource = data;
            _createCustomerView.customerType_comboBox.DisplayMember = "Description";
            _createCustomerView.customerType_comboBox.Refresh();
            _createCustomerView.ShowDialog();
        }

        public void CreateCustomer()
        {
            CustomerType selectedCustomerType = (CustomerType)_createCustomerView.customerType_comboBox.SelectedItem;

            if (string.IsNullOrWhiteSpace(_createCustomerView.name_textBox.Text))
            {
                MessageBox.Show("Por favor, ingresa un nombre válido.", "Campo de nombre vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (string.IsNullOrWhiteSpace(_createCustomerView.address_textBox.Text))
            {
                MessageBox.Show("Por favor, ingresa una dirección válida.", "Campo de dirección vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (selectedCustomerType == null)
            {
                MessageBox.Show("Por favor, selecciona un tipo de cliente.", "Tipo de cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            var customerModel = new Customer
            {
                CustName = _createCustomerView.name_textBox.Text,
                Adress = _createCustomerView.address_textBox.Text,
                Status = _createCustomerView.status_radioButton.Checked,
                CustomerTypeId = selectedCustomerType.Id
            };

            _customersModel.CreateCustomer(customerModel);
            _createCustomerView.Close();
        }
    }
}
