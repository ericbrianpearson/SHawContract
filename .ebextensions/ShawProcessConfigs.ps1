# This script is ran using an .ebextensions config file, executed under the container_commands section
# The script is processed from a staging directory, after the site has been extracted but before it has been deployed
# The working directory of container_commands is the root of the extracted site
# 02/20/2020 - RBM

# Environment Variables
# ---------------------
# RDS_DB_NAME
# RDS_HOSTNAME
# RDS_PASSWORD
# RDS_PORT
# RDS_USERNAME

# ConnectionStrings.config
# ------------------------
#<connectionStrings>
#  <clear />
#  <add name="CMSConnectionString" connectionString="Data Source=saue1scwsdrds1.c5amvvt8azeq.us-east-1.rds.amazonaws.com;Initial Catalog=shawcontract;Integrated Security=False;User Id=egobrie;Password=xxxxxxx;Persist Security Info=False;Connect Timeout=60;Encrypt=False;Current Language=English;" />
#</connectionStrings>

# SystemSettings.config
# ---------------------
#<appSettings>
#  <add key="KontentProjectId" value="1de26f59-f305-0033-7815-a4a479442a3f" />
#  <add key="KontentApiKey" value="ew0KICAiYWxnIjogIkhTMjU2IiwNCiAgInR5cCI6ICJKV1QiDQp9.ew0KICAianRpIjogImZkNTI0ZTdjZmUwMDQwZTliNGU1Yzc5N2QzZmEwNjZiIiwNCiAgImlhdCI6ICIxNTc0NDAxMzIxIiwNCiAgImV4cCI6ICIxOTIwMDAxMzIxIiwNCiAgInByb2plY3RfaWQiOiAiMWRlMjZmNTlmMzA1MDAzMzc4MTVhNGE0Nzk0NDJhM2YiLA0KICAidmVyIjogIjEuMC4wIiwNCiAgImF1ZCI6ICJkZWxpdmVyLmtlbnRpY29jbG91ZC5jb20iDQp9.3qmZWiuQ8E57xu5FT_ExMhMIj6FwT4rEavxWtmH0Vx4" />
#  <add key="KontentApiUrl" value="https://deliver.kenticocloud.com" />
#  <add key="UseCaching" value="false" />
#  <add key="CachingTimeoutMinutes" value="5" />
#  <add key="CMSApplicationGuid" value="8bfefbd5-5b49-48e0-a22f-06ea919200d7" />
#  <add key="CMSApplicationName" value="Default Web Site/ShawContract" />
#  <add key="CMSHashStringSalt" value="ea600eb3-27a0-49e1-a2d7-d489094437e6" />
#  <add key="CMSCIRepositoryPath" value="C:\inetpub\wwwroot\ShawContract\CMS\App_Data\CIRepository" />
#  <add key="ida:Tenant" value="shawincb2c.onmicrosoft.com" />
#  <add key="ida:ClientId" value="e7f9a6e2-5e5c-4fb0-9121-8ca3fef6f758" />
#  <add key="ida:AadInstance" value="https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration?p={1}" />
#  <add key="ida:SignInPolicyId" value="B2C_1_shawcontract" />
#  <add key="ida:RedirectUri" value="https://localhost:44380/" />
#</appSettings>

$configPath = "_ConfigFiles\"
$connectionConfig = "ConnectionStrings.config"

$rdsDB = (Get-ChildItem Env:RDS_DB_NAME).Value
$rdsHost = (Get-ChildItem Env:RDS_HOSTNAME).Value
$rdsPass = (Get-ChildItem Env:RDS_PASSWORD).Value
$rdsPort = (Get-ChildItem Env:RDS_PORT).Value
$rdsUser = (Get-ChildItem Env:RDS_USERNAME).Value

if (Test-Path -Path $configPath) {
  if (Test-Path -Path $configPath$connectionConfig) {
    Remove-Item -Path $configPath$connectionConfig -Force
  }
} else {
  New-Item -Path $configPath
}

"<connectionStrings>" | Add-Content -Path $configPath$connectionConfig
"  <clear />" | Add-Content -Path $configPath$connectionConfig
"  <add name=`"CMSConnectionString`" connectionString=`"Data Source=$rdsHost;Initial Catalog=$rdsDB;Integrated Security=False;User Id=$rdsUser;Password=$rdsPass;Persist Security Info=False;Connect Timeout=60;Encrypt=False;Current Language=English;`" />" | Add-Content -Path $configPath$connectionConfig
"</connectionStrings>" | Add-Content -Path $configPath$connectionConfig