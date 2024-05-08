# Enabling SqlServerCompact 

SqlCE offers file based EF db without external dependancies.

## Install SqlCE Database Engine
install before SSCERuntime-ENU.msi from here:

https://www.microsoft.com/en-us/download/details.aspx?id=30709&lc=1033
## Nuget Package
Add nuget -> EntityFramework.SqlServerCompact

## Example .config Files

### App.Config
```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
	<configSections>
		<!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
		<section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
	</configSections>
	<startup>
		<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8" />
	</startup>
	<connectionStrings>
		<add name="MyLocalDb" connectionString="Data Source=C:\SQLCompact\EFDataStore.sdf;" providerName="System.Data.SqlServerCe.4.0" />
	</connectionStrings>
	<entityFramework>
		<defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlCeConnectionFactory, EntityFramework">
			<parameters>
				<parameter value="System.Data.SqlServerCe.4.0" />
			</parameters>
		</defaultConnectionFactory>
		<providers>
			<provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
			<provider invariantName="System.Data.SqlServerCe.4.0" type="System.Data.Entity.SqlServerCompact.SqlCeProviderServices, EntityFramework.SqlServerCompact" />
		</providers>
	</entityFramework>
	<system.data>
		<DbProviderFactories>
			<remove invariant="System.Data.SqlServerCe.4.0" />
			<add name="Microsoft SQL Server Compact Data Provider 4.0" invariant="System.Data.SqlServerCe.4.0" description=".NET Framework Data Provider for Microsoft SQL Server Compact" type="System.Data.SqlServerCe.SqlCeProviderFactory, System.Data.SqlServerCe, Version=4.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" />
		</DbProviderFactories>
	</system.data>
</configuration>
```

### Web.Config (Wisej) 
```
<?xml version="1.0"?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  http://go.microsoft.com/fwlink/?LinkId=169433
  -->
<configuration>
	<configSections>
		<!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
		<section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
	</configSections>
	<startup>
		<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8" />
	</startup>
	<connectionStrings>
		<add name="MyLocalDb" connectionString="Data Source=C:\Documents\SQLCompact\EFDataStore.sdf;" providerName="System.Data.SqlServerCe.4.0" />
	</connectionStrings>
	<entityFramework>
		<defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlCeConnectionFactory, EntityFramework">
			<parameters>
				<parameter value="System.Data.SqlServerCe.4.0" />
			</parameters>
		</defaultConnectionFactory>
		<providers>
			<provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
			<provider invariantName="System.Data.SqlServerCe.4.0" type="System.Data.Entity.SqlServerCompact.SqlCeProviderServices, EntityFramework.SqlServerCompact" />
		</providers>
	</entityFramework>
	<system.data>
		<DbProviderFactories>
			<remove invariant="System.Data.SqlServerCe.4.0" />
			<add name="Microsoft SQL Server Compact Data Provider 4.0" invariant="System.Data.SqlServerCe.4.0" description=".NET Framework Data Provider for Microsoft SQL Server Compact" type="System.Data.SqlServerCe.SqlCeProviderFactory, System.Data.SqlServerCe, Version=4.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" />
		</DbProviderFactories>
	</system.data>
	<appSettings>
		<add key="Wisej.LicenseKey" value=""/>
		<add key="Wisej.DefaultTheme" value="Blue-1"/>
	</appSettings>
	<system.web>
		<compilation debug="true" />
		<httpRuntime targetFramework="4.8" maxRequestLength="1048576"/>
		<httpModules>
			<add name="Wisej" type="Wisej.Core.HttpModule, Wisej.Framework"/>
		</httpModules>
	</system.web>
	<system.webServer>
		<validation validateIntegratedModeConfiguration="false"/>
		<modules>
			<add name="Wisej" type="Wisej.Core.HttpModule, Wisej.Framework"/>
		</modules>
		<handlers>
			<add name="json" verb="*" path="*.json" type="System.Web.HttpForbiddenHandler" />
			<add name="wisej" verb="*" path="*.wx" type="Wisej.Core.HttpHandler, Wisej.Framework"/>
		</handlers>
		<security>
			<requestFiltering>
				<requestLimits maxAllowedContentLength="1073741824"/>
			</requestFiltering>
		</security>
		<defaultDocument enabled="true">
			<files>
				<add value="Default.html" />
			</files>
		</defaultDocument>
	</system.webServer>
	<!--<system.diagnostics>
    <trace autoflush="true" indentsize="4">
      <listeners>
        <remove name="Default" />
        <add name="Default" type="System.Diagnostics.TextWriterTraceListener" initializeData="Trace.log" />
      </listeners>
    </trace>
  </system.diagnostics>-->
</configuration>
```

## NOTE: Added sections to standard .config files
### Connection Name
- Add a connection 'name' to use in EF Designer
```
  <add name="MyLocalDb" connectionString="Data Source=C:\SQLCompact\EFDataStore.sdf;" providerName="System.Data.SqlServerCe.4.0" />
```
### entityFramework 
- Add defaultConnectionFactory parameter
- Add provider EntityFramework.SqlServerCompact
```
	<entityFramework>
		<defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlCeConnectionFactory, EntityFramework">
			<parameters>
				<parameter value="System.Data.SqlServerCe.4.0" />
			</parameters>
		</defaultConnectionFactory>
		<providers>
			<provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
			<provider invariantName="System.Data.SqlServerCe.4.0" type="System.Data.Entity.SqlServerCompact.SqlCeProviderServices, EntityFramework.SqlServerCompact" />
		</providers>
	</entityFramework>

```
