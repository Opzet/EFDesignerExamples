
## REST API Client Code Generator for VS 2022
	https://marketplace.visualstudio.com/items?itemName=ChristianResmaHelle.ApiClientCodeGenerator2022&ssr=false#review-details


## Kiota


Run in browser
You can run kiota with a modern web browser by navigating to https://app.kiota.dev/


https://learn.microsoft.com/en-us/openapi/kiota/using

The language CSharp is currently in Stable maturity level.
After generating code for this language, you need to install the following packages:
dotnet add package Microsoft.Kiota.Abstractions --version 1.0.0
dotnet add package Microsoft.Kiota.Http.HttpClientLibrary --version 1.0.0
dotnet add package Microsoft.Kiota.Serialization.Form --version 1.0.0
dotnet add package Microsoft.Kiota.Serialization.Json --version 1.0.1
dotnet add package Microsoft.Kiota.Authentication.Azure --version 1.0.0
dotnet add package Microsoft.Kiota.Serialization.Text --version 1.0.0


## REST Client
https://marketplace.visualstudio.com/items?itemName=humao.rest-client


https://github.com/microsoft/kiota-samples/tree/main/sample-api


//Add the base url to the path parameters


		if (string.IsNullOrEmpty(RequestAdapter.BaseUrl))
		{
			RequestAdapter.BaseUrl = "https://graph.microsoft.com/v1.0";
		}
		PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);