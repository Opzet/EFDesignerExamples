
using EventAnnotator;

namespace OIM.Domain.Model
{
    // Events
    public record Person(
        string Name,
        string Address
    );


    [CommandMetadata(
        domain: "Invoicing",
        name: "InvoiceInitiated",
        description: "The InvoiceInitiated command . ",
        version: "1.0",
        summary: "This command is used by the inventory management system to ",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/invoice",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "Invoicing channel"
    )]
    public record InvoiceInitiated(
        double Amount,
        string Number,
        Person IssuedTo,
        DateTime InitiatedAt
    );

    public record InvoiceIssued(
        string IssuedBy,
        DateTime IssuedAt
    );


    public enum InvoiceSendMethod
    {
        Email,
        Post
    }

    public record InvoiceSent(
        InvoiceSendMethod SentVia,
        DateTime SentAt
    );

    public enum InvoiceStatus
    {
        Initiated = 1,
        Issued = 2,
        Sent = 3
    }

    // Domain Model
    public class Invoice
    {
        public string Id
        {
            get; set;
        }
        public double Amount
        {
            get; private set;
        }
        public string Number
        {
            get; private set;
        }

        public InvoiceStatus Status
        {
            get; private set;
        }

        public Person IssuedTo
        {
            get; private set;
        }
        public DateTime InitiatedAt
        {
            get; private set;
        }

        public string IssuedBy
        {
            get; private set;
        }
        public DateTime IssuedAt
        {
            get; private set;
        }

        public InvoiceSendMethod SentVia
        {
            get; private set;
        }
        public DateTime SentAt
        {
            get; private set;
        }


        // Resolver
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
            Id = @event.Number;
            Amount = @event.Amount;
            Number = @event.Number;
            IssuedTo = @event.IssuedTo;
            InitiatedAt = @event.InitiatedAt;
            Status = InvoiceStatus.Initiated;
        }

        private void Apply(InvoiceIssued @event)
        {
            IssuedBy = @event.IssuedBy;
            IssuedAt = @event.IssuedAt;
            Status = InvoiceStatus.Issued;
        }

        private void Apply(InvoiceSent @event)
        {
            SentVia = @event.SentVia;
            SentAt = @event.SentAt;
            Status = InvoiceStatus.Sent;
        }
    }
}