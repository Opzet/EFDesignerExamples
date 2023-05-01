 
## Enterprise app with webApi 
#  using Entity Framework, WebAPI with Swashbuckle, and a client app that consumes the API:

Step-by-step process for creating;

1. Create a new Visual Studio solution and add a new "Class Library" project called DAL.
	This serves as the data access layer (DAL) for your app. 
	This project will contain your Entity Framework data models, and will expose methods for CRUD operations.

2. Add your Entity Framework data models to the DAL project. 
	You can use the Entity Framework visual modeler to create the data models, or write the code manually. 
	Ensure that the models are set up correctly with any necessary relationships, keys, and constraints.

3. Add a new "WebAPI" project to your solution. 
	This project will serve as the API layer for your app, exposing endpoints that can be called by clients to interact with the data stored in the DAL.

4. Add a reference to the DAL project in the WebAPI project. 
	This will allow the WebAPI project to access the data models and methods in the DAL.

5. Install the Swashbuckle NuGet package in your WebAPI project. 
	This package will generate Swagger UI and a Swagger JSON file for your API.

	```Install-Package Swashbuckle.AspNetCore```

6. Configure Swashbuckle in your WebAPI project by adding a new SwaggerConfig class that sets up the Swagger endpoints and UI.
	You can also customize the Swagger UI with additional information about your API.

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger(c =>
			{
				c.SerializeAsV2 = true;
			});

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = "swagger";
			});
		}

7. Build and run your WebAPI project to ensure that the Swagger UI is accessible and the Swagger JSON file is being generated correctly.

		At the simplest end, we now have basic HTTP APIs:

		You make a request to a URI, and it responds with data, hopefully in the format you requested (JSON, XML, etc.).
		
		This includes APIs that strictly conform with the ReST architectural style,but also simple 

		**“CRUD-over-HTTP”** APIs that just use 
		 - GET, PUT, POST and DELETE requests to retrieve, store and manage data.

		These APIs can apply security using any of the available HTTP authentication options,
		and can be made secure simply by applying SSL/TLS to the connection.

		HTTP APIs created with .NET Core are self documented using Swagger.

		This includes the ability to read the API metadata from a known endpoint and generate client library code.

8. Add a new "Client App" project to your solution.
	This project can be any type of app that consumes REST APIs, such as a Windows Forms app or a console app.

9. Use a tool like Swagger Codegen or an API client library to generate client code for your API. 
	This will create classes and methods that can be used to call the endpoints in your WebAPI project.

10. Add the generated client code to your client app project, and use it to interact with your API. 
	You can test your app by running the client app and verifying that it is able to retrieve and manipulate data through the API.




---  REFERENCE ---

[Book on Learning Microservices](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/data-driven-crud-microservice)

Free course Create and deploy a cloud-native [ASP.NET Core microservice on MS Learn](https://docs.microsoft.com/en-us/learn/modules/microservices-aspnet-core/)

![Request/Response](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/media/communication-in-microservice-architecture/request-response-comms-live-queries-updates.png)

![Architecture](https://github.com/dotnet-architecture/eShopOnContainers/raw/dev/img/eShopOnContainers-architecture.png)

[Example Programs](https://github.com/dotnet-architecture/eShopOnContainers?WT.mc_id=dotnet-35129-website)

