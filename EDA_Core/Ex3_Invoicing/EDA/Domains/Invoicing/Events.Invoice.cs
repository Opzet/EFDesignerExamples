
using EventAnnotator;
using Ex3_Invoicing.Model;
using static Ex3_Invoicing.Model.Invoice;

namespace Ex3_Invoicing.Events.Invoice
{
    [CommandMetadata(
        domain: "Invoicing",
        name: "InvoiceInitiated",
        description: "The InvoiceInitiated command.",
        version: "1.0",
        summary: "This command is used by the inventory management system to initiate an invoice.",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/invoice",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "Invoicing channel"
        )]
    public class InvoiceInitiated : IEvent
    {
        public Guid Id
        {
            get; private set;
        }
        public DateTime OccurredOn
        {
            get; private set;
        }
        public string Number
        {
            get; private set;
        }
        public double Amount
        {
            get; private set;
        }
        public Person Customer
        {
            get; private set;
        }
        public DateTime InitiatedAt
        {
            get; private set;
        }

        public InvoiceInitiated(string number, double amount, Person customer, DateTime initiatedAt)
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
            Number = number;
            Amount = amount;
            Customer = customer;
            InitiatedAt = initiatedAt;
        }
    }

    [CommandMetadata(
        domain: "Invoicing",
        name: "InvoiceIssued",
        description: "The InvoiceIssued command.",
        version: "1.0",
        summary: "This command is used by the inventory management system to issue an invoice.",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/invoice",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "Invoicing channel"
        )]
    public class InvoiceIssued : IEvent
    {
        public Guid Id
        {
            get; private set;
        }
        public DateTime OccurredOn
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

        public InvoiceIssued(string issuedBy, DateTime issuedAt)
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
            IssuedBy = issuedBy;
            IssuedAt = issuedAt;
        }
    }

    [CommandMetadata(
        domain: "Invoicing",
        name: "InvoiceSent",
        description: "The InvoiceSent command.",
        version: "1.0",
        summary: "This command is used by the inventory management system to send an invoice.",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/invoice",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "Invoicing channel"
        )]
    public class InvoiceSent : IEvent
    {
        public Guid Id
        {
            get; private set;
        }
        public DateTime OccurredOn
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

        public InvoiceSent(InvoiceSendMethod sentVia, DateTime sentAt)
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
            SentVia = sentVia;
            SentAt = sentAt;
        }
    }
    [CommandMetadata(
        domain: "Invoicing",
        name: "InvoicePaid",
        description: "The InvoicePaid command.",
        version: "1.0",
        summary: "This command is used by the inventory management system to mark an invoice as paid.",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/invoice",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "Invoicing channel"
        )]
    public class InvoicePaid : IEvent
    {
        public Guid Id
        {
            get; private set;
        }
        public DateTime OccurredOn
        {
            get; private set;
        }
        public string InvoiceNumber
        {
            get; private set;
        }
        public double AmountPaid
        {
            get; private set;
        }
        public DateTime PaidAt
        {
            get; private set;
        }

        public InvoicePaid(string invoiceNumber, double amountPaid, DateTime paidAt)
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
            InvoiceNumber = invoiceNumber;
            AmountPaid = amountPaid;
            PaidAt = paidAt;
        }
    }
}