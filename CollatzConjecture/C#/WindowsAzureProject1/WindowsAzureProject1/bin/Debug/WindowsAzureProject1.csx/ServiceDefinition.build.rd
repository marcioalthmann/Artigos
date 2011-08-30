<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzureProject1" generation="1" functional="0" release="0" Id="161d4d0e-e284-4183-bf0c-d6a88a9b5526" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzureProject1Group" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WebRole1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/LB:WebRole1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WebRole1:?IsSimulationEnvironment?" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/MapWebRole1:?IsSimulationEnvironment?" />
          </maps>
        </aCS>
        <aCS name="WebRole1:?RoleHostDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/MapWebRole1:?RoleHostDebugger?" />
          </maps>
        </aCS>
        <aCS name="WebRole1:?StartupTaskDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/MapWebRole1:?StartupTaskDebugger?" />
          </maps>
        </aCS>
        <aCS name="WebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebRole1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/MapWebRole1Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WebRole1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWebRole1:?IsSimulationEnvironment?" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1/?IsSimulationEnvironment?" />
          </setting>
        </map>
        <map name="MapWebRole1:?RoleHostDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1/?RoleHostDebugger?" />
          </setting>
        </map>
        <map name="MapWebRole1:?StartupTaskDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1/?StartupTaskDebugger?" />
          </setting>
        </map>
        <map name="MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebRole1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WebRole1" generation="1" functional="0" release="0" software="E:\Artigos\CollatzConjecture\C#\WindowsAzureProject1\WindowsAzureProject1\bin\Debug\WindowsAzureProject1.csx\roles\WebRole1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="?IsSimulationEnvironment?" defaultValue="" />
              <aCS name="?RoleHostDebugger?" defaultValue="" />
              <aCS name="?StartupTaskDebugger?" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebRole1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1Instances" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyID name="WebRole1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="1f1059d9-94d3-4221-8690-f635bda3e1e0" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzureProject1Contract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="80b0280b-4c3c-421e-836b-0dc3149d6e9b" ref="Microsoft.RedDog.Contract\Interface\WebRole1:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/WindowsAzureProject1/WindowsAzureProject1Group/WebRole1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>