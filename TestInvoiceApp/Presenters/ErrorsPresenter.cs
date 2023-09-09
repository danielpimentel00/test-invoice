using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestInvoiceApp.Presenters
{
    public class ErrorsPresenter
    {
        public void DisplayMessage(string message, string header, MessageBoxIcon messageType)
        {
            MessageBox.Show(message, header, MessageBoxButtons.OK, messageType);
        }
    }
}
