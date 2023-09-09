using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInvoiceApp.Presenters;

namespace TestInvoiceApp.Models
{
    public class CustomerTypesModel
    {
		private readonly Test_InvoiceEntities _context;
		private readonly ErrorsPresenter _errorsPresenter;

        public CustomerTypesModel()
		{
			_context = new Test_InvoiceEntities();
			_errorsPresenter = new ErrorsPresenter();
		}

        public List<CustomerType> GetCustomerTypes() {
			try
			{
				var list = _context.CustomerTypes.ToList();
				return list;
            }
			catch (Exception)
			{
				throw;
			}
        }

		public void AddCustomerType(string description)
		{
			try
			{
				_context.CustomerTypes.Add(new CustomerType
				{
					Description = description
				});
				_context.SaveChanges();
			}
			catch (Exception)
			{ 
				throw;
			}
		}

		public void RemoveCustomerType(CustomerType model)
		{
			try
			{
				// Validar que no haya registros relacionados en otras tablas con el que se va a eliminar
				var relatedRecords = _context.Customers.FirstOrDefault(x => x.CustomerTypeId == model.Id);

				if(relatedRecords != null)
				{
                    throw new InvalidOperationException("Hay clientes asociados a este tipo");
                }

                var customerToDeleted = _context.CustomerTypes.FirstOrDefault(c => c.Id == model.Id);
                if (customerToDeleted != null)
                {
                    _context.CustomerTypes.Remove(customerToDeleted);
                    _context.SaveChanges();
                }
			}
            catch (InvalidOperationException ex)
            {
                _errorsPresenter.DisplayMessage(ex.Message, "Operación no permitida", MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                //MessageBox.Show("Ocurrió un error inesperado al eliminar el tipo de cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw;
            }
        }
    }
}
