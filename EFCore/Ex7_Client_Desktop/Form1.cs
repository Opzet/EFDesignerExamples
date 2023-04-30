using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Refit;

using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClient;

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




            textBox1.Text = "";



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

            //// Microsoft.Kiota
            //// Create an instance of the HttpClientFactory
            //var httpClientFactory = new System.Net.Http.HttpClientFactory();

            //// Set the base URL for the API
            //var baseUrl = "https://api.example.com/v1/";

            //// Create an instance of the HttpClient using the factory
            //var httpClient = httpClientFactory.CreateClient();

            //// Create a new instance of the HttpCore class, passing in the HttpClient and base URL
            //var httpCore = new HttpCore(httpClient, baseUrl);

            //// Create a new instance of the KiotaClient class, passing in the HttpCore
            //var kiotaClient = new KiotaClient(httpCore);

            //// Now you can use the kiotaClient object to make requests to the API

            //// API requires no authentication, so use the anonymous
            //// authentication provider
            //var authProvider = new AnonymousAuthenticationProvider();
            //// Create request adapter using the HttpClient-based implementation
            //var adapter = new HttpClientRequestAdapter(authProvider);
            //// Create the API client
            //var client = new ApiClient(adapter);

            //List<Models.Student>? allStudents = await client.Api.Students.GetAsync();
            //Console.WriteLine($"Retrieved {allStudents?.Count} students.");

            ////ApiClient client = new ApiClient("https://localhost:7149");
            ////var students = client.Api.Students.

            ////    .StudentsAllAsync().GetAwaiter().GetResult();


            //foreach (Models.Student st in allStudents)
            //{
            //    textBox1.Text += st.ToString() + "\r\n";
            //}
        }
    }
}