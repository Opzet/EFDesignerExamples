using Ex3_Invoicing.Events;
using Ex3_Invoicing.Infrastructure;
using Ex3_Invoicing.Model;
using Ex3_Invoicing.Resolve;

using static Ex3_Invoicing.Model.Invoice;
using Ex3_Invoicing.Events.Invoice;
using EventAnnotator.Domain.Events;


namespace Ex3_Invoicing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DemoEventSourcing();
        }

        static void DemoEventSourcing()
        {
            // Events are immutable and are used to capture and persist these state changes.

            EventStore eventStore = new EventStore();

            Console.WriteLine($"\r\n{new string('-', 50)}{Environment.NewLine}EDA with Event Sourcing{Environment.NewLine}{new string('-', 50)}");

            Console.WriteLine($"Adding events to the event store...");

            var invoiceInitiated = new InvoiceInitiated(
                "INV/2021/11/01",
                34.12,
                new Person("Oscar the Grouch", "123 Sesame Street"),
                DateTime.UtcNow
            );
            eventStore.Append(invoiceInitiated);

            var invoiceIssued = new InvoiceIssued(
                "Cookie Monster",
                DateTime.UtcNow
            );
            eventStore.Append(invoiceIssued);

            var invoiceSent = new InvoiceSent(
                InvoiceSendMethod.Email,
                DateTime.UtcNow
            );
            eventStore.Append(invoiceSent);

            // Get all events from the event store
            var events = eventStore.GetAllEvents();

            // Construct empty Invoice object
            var invoiceView = new Invoice();

            InvoiceAggregrate invoiceAggregrate = new InvoiceAggregrate();
            Console.WriteLine($"\r\n{new string('-', 50)}{Environment.NewLine}invoiceAggregrate{Environment.NewLine}{new string('-', 50)}");

            int sequence = 0;
            // Apply each event on the entity and print details
            foreach (var @event in events.OrderBy(e => e.OccurredOn))
            {
                sequence++;
                
                invoiceAggregrate.Evolve(@event);

                invoiceView = invoiceAggregrate.invoiceRendered;

                // Print event details
                Console.WriteLine($"\r\n{new string('-', 50)}{Environment.NewLine}Event [{sequence}] Applied: {@event.GetType().Name}{Environment.NewLine}{new string('-', 50)}");
                switch (@event)
                {
                    case InvoiceInitiated e:
                        Console.WriteLine($"Invoice Number: {e.Number}");
                        Console.WriteLine($"Amount: {e.Amount}");
                        Console.WriteLine($"Customer: {e.Customer.Name}, Address: {e.Customer.Address}");
                        Console.WriteLine($"Date: {e.InitiatedAt}");
                        break;
                    case InvoiceIssued e:
                        Console.WriteLine($"Issued By: {e.IssuedBy}");
                        Console.WriteLine($"Date: {e.IssuedAt}");
                        break;
                    case InvoiceSent e:
                        Console.WriteLine($"Send Method: {e.SentVia}");
                        Console.WriteLine($"Date: {e.SentAt}");
                        break;
                }

                // Print current state of the invoice
                Console.WriteLine($"{new string('-', 50)}{Environment.NewLine}Current Invoice State{Environment.NewLine}{new string('-', 50)}");
                Console.WriteLine($"Invoice Number: {invoiceView.Number}");
                Console.WriteLine($"Amount: {invoiceView.Amount}");
                Console.WriteLine($"Customer: {invoiceView.Customer?.Name}, Address: {invoiceView.Customer?.Address}");
                Console.WriteLine($"Issued By: {invoiceView.IssuedBy}");
                Console.WriteLine($"Send Method: {invoiceView.SentVia}");
            }

            // Wait for user input at the end
            Console.ReadLine();
        }
    }
}
