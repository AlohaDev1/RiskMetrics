

MetricsCorporation
admin
1q2w3e4r
server=localhost;User Id=root;password=1111;Persist Security Info=True;database=state_schematic
Prefix: orchard
Default



Create modules
1. install CodeGeneration from gallery
2. go cmd
3. go to ProspectBase\Metrics\Orchard.Web.1.6\Orchard\bin
4. enter orchard.exe
5. feature enable Orchard.CodeGeneration
6. codegen modele MetricsWEbExample
7.if  codegen fail then do all steps with sources.
8. modify dependencies xml and in cmd feature enable MetricsCorporation.Orchard.Web
9. modify dependencies xml and in cmd feature enable MetricsCorporation.Orchard.Api



dependencies.xml

  <Dependency>
    <ModuleName>MetricsCorporation.Orchard.Web</ModuleName>
    <VirtualPath>~/Modules/MetricsCorporation.Orchard.Web/MetricsCorporation.Orchard.Web.csproj</VirtualPath>
    <LoaderName>DynamicExtensionLoader</LoaderName>
    <References />
  </Dependency>
  <Dependency>
    <ModuleName>MetricsCorporation.Orchard.Api</ModuleName>
    <VirtualPath>~/Modules/MetricsCorporation.Orchard.Api/MetricsCorporation.Orchard.Api.csproj</VirtualPath>
    <LoaderName>DynamicExtensionLoader</LoaderName>
    <References />
  </Dependency>
  
  
  To 
  dependencies.compiled.xml
  
  
  
    <Dependency>
    <ExtensionId>MetricsCorporation.Orchard.Web</ExtensionId>
    <LoaderName>DynamicExtensionLoader</LoaderName>
    <VirtualPath>~/Modules/MetricsCorporation.Orchard.Web/MetricsCorporation.Orchard.Web.csproj</VirtualPath>
    <Hash>4930c12f025fdb64</Hash>
  </Dependency>
  <Dependency>
    <ExtensionId>MetricsCorporation.Orchard.Api</ExtensionId>
    <LoaderName>DynamicExtensionLoader</LoaderName>
    <VirtualPath>~/Modules/MetricsCorporation.Orchard.Api/MetricsCorporation.Orchard.Api.csproj</VirtualPath>
    <Hash>4930c12f025fdb64</Hash>
  </Dependency>