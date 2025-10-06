
using Ex3_Invoicing.Events.Invoice;
using static Ex3_Invoicing.Model.Invoice;


namespace Ex3_Invoicing.Resolve
{
    public class InvoiceAggregrate
    {
        //Aggregrate Root
        public Model.Invoice invoiceRendered = new Model.Invoice();
        // Resolve
        public void Evolve(object @event)
        {
            switch (@event)
            {
                case InvoiceInitiated invoiceInitiated:
                    Apply(invoiceInitiated);
                    break;
                case InvoiceIssued invoiceIssued:
                    Apply(invoiceIssued);
                    break;
                case InvoiceSent invoiceSent:
                    Apply(invoiceSent);
                    break;
            }
        }

        private void Apply(InvoiceInitiated @event)
        {
            invoiceRendered.Id = @event.Number;
            invoiceRendered.Amount = @event.Amount;
            invoiceRendered.Number = @event.Number;
            invoiceRendered.Customer = @event.Customer;
            invoiceRendered.InitiatedAt = @event.InitiatedAt;
            invoiceRendered.Status = InvoiceStatus.Initiated;
        }

        private void Apply(InvoiceIssued @event)
        {
            invoiceRendered.IssuedBy = @event.IssuedBy;
            invoiceRendered.IssuedAt = @event.IssuedAt;
            invoiceRendered.Status = InvoiceStatus.Issued;
        }

        private void Apply(InvoiceSent @event)
        {
            invoiceRendered.SentVia = @event.SentVia;
            invoiceRendered.SentAt = @event.SentAt;
            invoiceRendered.Status = InvoiceStatus.Sent;
        }
    }
}