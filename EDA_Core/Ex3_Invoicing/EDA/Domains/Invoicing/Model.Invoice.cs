
using EventAnnotator;

namespace Ex3_Invoicing.Model
{

    public record Person(
         string Name,
         string Address
  );

    public class Invoice
    {
        public enum InvoiceSendMethod
        {
            Email,
            Post
        }

        public enum InvoiceStatus
        {
            Initiated = 1,
            Issued = 2,
            Sent = 3
        }

        public string Id
        {
            get; set;
        }
        public double Amount
        {
            get; internal set;
        }
        public string Number
        {
            get; internal set;
        }

        public InvoiceStatus Status
        {
            get; internal set;
        }

        public Person Customer
        {
            get; internal set;
        }
        public DateTime InitiatedAt
        {
            get; internal set;
        }

        public string IssuedBy
        {
            get; internal set;
        }
        public DateTime IssuedAt
        {
            get; internal set;
        }

        public InvoiceSendMethod SentVia
        {
            get; internal set;
        }
        public DateTime SentAt
        {
            get; internal set;
        }
    }
}