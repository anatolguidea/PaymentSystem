using PaymentSystem.Factories;
using PaymentSystem.Models;

namespace PaymentSystem.Services
{
    public class PaymentFacade
    {
        private readonly InvoiceFactory _invoiceFactory;
        private readonly PaymentFactory _paymentFactory;

        public PaymentFacade()
        {
            _invoiceFactory = new InvoiceFactory();
            _paymentFactory = new PaymentFactory();
        }

        public void ProceseazaPlata(string tipFactura, string metodaPlata)
        {
            Console.WriteLine("Se genereaz? factura...");
            var factura = _invoiceFactory.CreateInvoice(tipFactura, 100, 120, 2.5m);
            factura.GenerateInvoice();

            Console.WriteLine("Se proceseaz? plata...");
            var procesator = _paymentFactory.CreatePaymentProcessor(metodaPlata);
            procesator.ProcessPayment(100, "MDL");


        }
    }
}
