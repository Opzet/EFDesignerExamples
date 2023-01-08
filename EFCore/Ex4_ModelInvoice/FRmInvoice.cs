using System;
using System.Windows.Forms;

using System.Data.Entity.Validation;
using Microsoft.EntityFrameworkCore;


namespace Ex4_ModelInvoice
{
    public partial class FrmInvoice : Form
    {
        DbContextOptionsBuilder<AccountingSystemModel> optionsBuilder;

        public FrmInvoice()
        {
            InitializeComponent();
            optionsBuilder = new DbContextOptionsBuilder<AccountingSystemModel>();
            optionsBuilder.UseSqlServer(AccountingSystemModel.ConnectionString);
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableDetailedErrors();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            txtDebug.Text = "TestOne2One()\r\n";

            using (AccountingSystemModel db = new AccountingSystemModel(optionsBuilder.Options))
            {
                txtConnection.Text = AccountingSystemModel.ConnectionString;

                // Perform data access using the context


                txtDebug.Text += "\r\nEx 4: Invoice - Header and Detail\r\n----------------\r\n";

                db.Database.EnsureDeleted();
                txtDebug.Text += "Deleted DB\r\n";

                db.Database.EnsureCreated();
                txtDebug.Text += "Created DB\r\n";

                InvoiceHeaders invHeader = new InvoiceHeaders();
                InvoiceDetails invDetails = new InvoiceDetails(invHeader);

                invHeader.Total = 150M;

                invDetails.ItemDescription = "New Item";
                invDetails.Price = 75M;
                invDetails.Quantity = 2;

                //Associate Header and Details
                invHeader.InvoiceDetails.Add(invDetails);

                //Save rows to Db
                db.InvoiceHeaders.Add(invHeader);
                db.InvoiceDetails.Add(invDetails);

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (DbEntityValidationResult validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (DbValidationError validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting the current instance as InnerException  
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;

                }

                //Read it back
                DbSet<InvoiceHeaders> records = db.InvoiceHeaders;

                foreach (InvoiceHeaders record in records)
                {
                    txtDebug.Text += String.Format("Invoice Id {0} - Total: {1}", record.Id, record.Total) + "\r\n"; ;

                    txtDebug.Text += "--- Detail --\r\n";

                    //TODO: Error? There is already an open DataReader associated with this Command which must be closed first.
                    //Cannot figure out how to get detail data?
                    //foreach (InvoiceDetails details in record.InvoiceDetails)
                    //{
                    //  // txtDebug.Text += String.Format("Invoice Id {0} - Total: {1} |  Details Desc:{2} Qty:{3} Price:{4} Total:{5}", record.Id, record.Total, details.ItemDescription, details.Quantity, details.Price, details.Total) + "\r\n";
                    //}

                }
            }
        }

        private void FRmInvoice_Load(object sender, EventArgs e)
        {

            using (AccountingSystemModel db = new AccountingSystemModel(optionsBuilder.Options))
            {
                txtConnection.Text = AccountingSystemModel.ConnectionString;
            }
        }
    }
}