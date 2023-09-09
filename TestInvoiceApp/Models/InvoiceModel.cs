using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvoiceApp.Models
{
    public class InvoiceCalcs
    {
        public decimal Subtotal { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal Total { get; set; }
    }

    public class InvoiceDetailModelArgs
    {
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class InvoiceModel
    {
        private readonly Test_InvoiceEntities _context;

        public InvoiceModel()
        {
            _context = new Test_InvoiceEntities();
        }

        public List<Invoice> GetInvoices()
        {
            try
            {
                var result = _context.Invoices.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateInvoiceWithDetails(List<InvoiceDetailModelArgs> invoiceDetailList)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var groupedByCustomerId = invoiceDetailList.GroupBy(detail => detail.CustomerId);

                foreach (var group in groupedByCustomerId)
                {
                    int customerId = group.Key;
                    var totalCalcs = new InvoiceCalcs();

                    var invoice = _context.Invoices.Add(new Invoice
                    {
                        CustomerId = customerId,
                        SubTotal = 0,
                        TotalItbis = 0,
                        Total = 0
                    });
                    _context.SaveChanges();

                    foreach (var detail in group)
                    {
                        var calcs = CalculateTotals(detail);

                        CreateInvoiceDetail(new InvoiceDetail
                        {
                            Price = detail.Price,
                            Qty = detail.Quantity,
                            SubTotal = calcs.Subtotal,
                            TotalItbis = calcs.TotalItbis,
                            Total = calcs.Total,
                            InvoiceId = invoice.Id
                        });

                        totalCalcs.Subtotal += calcs.Subtotal;
                        totalCalcs.TotalItbis += calcs.TotalItbis;
                        totalCalcs.Total += calcs.Total;
                    }

                    invoice.SubTotal = totalCalcs.Subtotal;
                    invoice.TotalItbis = totalCalcs.TotalItbis;
                    invoice.Total = totalCalcs.Total;
                }

                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private InvoiceCalcs CalculateTotals(InvoiceDetailModelArgs args)
        {
            var subtotal = args.Price * args.Quantity;
            var totalItbis = subtotal * 0.18m;
            var total = subtotal + totalItbis;

            return new InvoiceCalcs
            {
                Subtotal = subtotal,
                TotalItbis = totalItbis,
                Total = total
            };
        }

        private void CreateInvoiceDetail(InvoiceDetail model)
        {
            try
            {
                _context.InvoiceDetails.Add(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Event handler para cuando se crea detalle de invoice
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        //public void OnInvoiceDetailCreated(object s, InvoiceDetailArgs args)
        //{
        //    var transaction = _context.Database.BeginTransaction();

        //    try
        //    {
        //        //var invoice = _context.Invoices.FirstOrDefault(x => x.CustomerId == args.CustomerId);

        //        //if(invoice != null)
        //        //{
        //        //    invoiceId = invoice.Id;
        //        //    invoice.SubTotal += args.Subtotal;
        //        //    invoice.TotalItbis += args.TotalItbis;
        //        //    invoice.Total += args.Total;

        //        //    _context.Entry(invoice).State = EntityState.Modified;

        //        //} else
        //        //{
        //        //    var newInvoice = new Invoice
        //        //    {
        //        //        CustomerId = args.CustomerId,
        //        //        SubTotal = args.Subtotal,
        //        //        TotalItbis = args.TotalItbis,
        //        //        Total = args.Total,
        //        //    };

        //        //    _context.Invoices.Add(newInvoice);
        //        //    _context.SaveChanges();
        //        //    invoiceId = newInvoice.Id;
        //        //}

        //        var newInvoice = new Invoice
        //        {
        //            CustomerId = args.CustomerId,
        //            SubTotal = args.Subtotal,
        //            TotalItbis = args.TotalItbis,
        //            Total = args.Total,
        //        };

        //        _context.Invoices.Add(newInvoice);
        //        _context.SaveChanges();
        //        int invoiceId = newInvoice.Id;

        //        _context.InvoiceDetails.Add(new InvoiceDetail
        //        {
        //            InvoiceId = invoiceId,
        //            Price = args.Price,
        //            Qty = args.Quantity,
        //            SubTotal = args.Subtotal,
        //            TotalItbis = args.TotalItbis,
        //            Total = args.Total,
        //        });

        //        _context.SaveChanges();
        //        transaction.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}
    }
}
