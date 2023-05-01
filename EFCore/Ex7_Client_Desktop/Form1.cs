using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Refit;

using Microsoft.Kiota.Abstractions;
//using Microsoft.Kiota.Http.HttpClient;

namespace Ex7_Client_Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnListStudents_Click(object sender, EventArgs e)
        {
            //// ------ Using Microsoft.Kiota ------------
            //// Create an instance of the HttpClientFactory

            // API requires no authentication, so use the anonymous
            // authentication provider
            var authProvider = new AnonymousAuthenticationProvider();
            // Create request adapter using the HttpClient-based implementation
            var RequestAdapter = new HttpClientRequestAdapter(authProvider);
            // Create the API client

            // Set the base URL for the API
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl))
            {
                RequestAdapter.BaseUrl = "https://localhost:7149"; 
            }

            //PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
            var client = new ApiClient(RequestAdapter);

            List<Models.Student>? allStudents = await client.Api.Students.GetAsync();

            textBox1.Text = $"-----------------------------------------\r\n" +
                            $" Retrieved {allStudents?.Count} Students.\r\n" +
                            $"-----------------------------------------\r\n";

            foreach (Models.Student st in allStudents)
            {
                textBox1.Text += st?.FirstName?.ToString() + "\r\n";
            }

            // --------------------------------


            // --------- RIFITTER ------------
            /*      REST API Client Code Generator v1.7.12.0 on 30/04/2023 10:05:49 PM
            //      Using the tool Refitter v0.4.1   

            var client = RestService.For<IEx7_WebApi>("https://localhost:7149/swagger/api/Students");
            
            //if(client.response)
            
            var students = await client.StudentsAll();
            // --------------------------------

            */
            // ---------- NSWAG --------------
            /*
            //     Generated REST API Client Code Generator v1.7.12.0 on 30/04/2023 10:29:41 PM
            //     Using the tool NSwag v13.18.2 http://nswag.org/
            Console.WriteLine("Welcome to Nswag Generated Client");

            // Created object of class ValuesClient  
            //var client = new HttpClient("https://localhost:7149");

            var testClient = new Ex7_WebApiClient(client);

            // Call GetAsync Values API  
            // var getresult = testClient.GetAsync(1).GetAwaiter().GetResult();
            // --------------------------------

            // Call GetAllAsync Values API  
            var students = testClient.StudentsAllAsync().GetAwaiter().GetResult();
            */


        }
    }
}