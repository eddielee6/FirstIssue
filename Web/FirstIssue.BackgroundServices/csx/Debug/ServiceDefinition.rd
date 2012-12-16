<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="FirstIssue.BackgroundServices" generation="1" functional="0" release="0" Id="d1757a7b-3b65-4774-9eed-f462c0ac4435" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="FirstIssue.BackgroundServicesGroup" generation="1" functional="0" release="0">
      <settings>
        <aCS name="PushNotificationService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/FirstIssue.BackgroundServices/FirstIssue.BackgroundServicesGroup/MapPushNotificationService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="PushNotificationServiceInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/FirstIssue.BackgroundServices/FirstIssue.BackgroundServicesGroup/MapPushNotificationServiceInstances" />
          </maps>
        </aCS>
      </settings>
      <maps>
        <map name="MapPushNotificationService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/FirstIssue.BackgroundServices/FirstIssue.BackgroundServicesGroup/PushNotificationService/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapPushNotificationServiceInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/FirstIssue.BackgroundServices/FirstIssue.BackgroundServicesGroup/PushNotificationServiceInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="PushNotificationService" generation="1" functional="0" release="0" software="C:\Users\Matt\Documents\GitHub\FirstIssue\Web\FirstIssue.BackgroundServices\csx\Debug\roles\PushNotificationService" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;PushNotificationService&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;PushNotificationService&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/FirstIssue.BackgroundServices/FirstIssue.BackgroundServicesGroup/PushNotificationServiceInstances" />
            <sCSPolicyUpdateDomainMoniker name="/FirstIssue.BackgroundServices/FirstIssue.BackgroundServicesGroup/PushNotificationServiceUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/FirstIssue.BackgroundServices/FirstIssue.BackgroundServicesGroup/PushNotificationServiceFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="PushNotificationServiceUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="PushNotificationServiceFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="PushNotificationServiceInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
</serviceModel>