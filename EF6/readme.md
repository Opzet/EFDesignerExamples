# SqlServerCompact 
## Install SqlCE Database Engine
install before SSCERuntime-ENU.msi from here:

https://www.microsoft.com/en-us/download/details.aspx?id=30709&lc=1033
## Nuget Package
Add nuget -> EntityFramework.SqlServerCompact

## App.config 
```
<add name="MyLocalDb" connectionString="Data Source=EFVisualExamples.sdf;" providerName="System.Data.SqlServerCe.4.0" />
```
