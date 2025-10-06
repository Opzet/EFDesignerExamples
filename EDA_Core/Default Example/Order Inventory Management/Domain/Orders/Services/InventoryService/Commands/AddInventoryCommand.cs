
using EventAnnotator;

namespace OIM.Domain.Commands
{
    //https://demo.eventcatalog.dev/

    [CommandMetadata(
        domain: "Orders",
        name: "AddInventoryCommand",
        description: "The AddInventory command is issued to add new stock to the inventory. ",
        version: "1.0",
        summary: "This command is used by the inventory management system to update the quantity of products available in the warehouse or store..",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/register",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "User registration channel"
    )]
    public class AddInventoryCommand
    {
        public Guid ProductId
        {
            get; set;
        }
        public int Quantity
        {
            get; set;
        }
        public Guid WarehouseId
        {
            get; set;
        }
        public DateTime Timestamp
        {
            get; set;
        }
    }
}
