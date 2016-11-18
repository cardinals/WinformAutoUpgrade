
1.增量更新 update.config 跟服务器updateService.xml对比
2.主界面显示更新内容或通知信息，从本地的help.txt中读取.


--------------updateService.xml -----------------

<?xml version="1.0" encoding="utf-8"?>
<updateFiles>
  <!--<file path="BLL.dll"  url="http://localhost:6666/ReleaseVersion/BLL.dll" lastver="1.0.0.2" size="4196" needRestart="true" />
  <file path="bll\BLL1.dll"  url="http://localhost:6666/ReleaseVersion/bll/BLL1.dll" lastver="1.0.0.1" size="4196" needRestart="true" />
  <file path="DAL.dll"  url="http://localhost:6666/ReleaseVersion/DAL.dll" lastver="1.0.0.2" size="4196" needRestart="true" />
  <file path="Log.config"  url="http://localhost:6666/ReleaseVersion/Log.config" lastver="1.0.0.3" size="1227" needRestart="true" />
  <file path="log4net.dll"  url="http://localhost:6666/ReleaseVersion/log4net.dll" lastver="1.0.0.2" size="271336" needRestart="true" />
  <file path="UpgradeClient.exe"  url="http://localhost:6666/ReleaseVersion/UpgradeClient.exe" lastver="1.0.0.1" size="24064" needRestart="true" />
  <file path="help.txt"  url="http://localhost:6666/ReleaseVersion/help.txt" lastver="1.0.0.3" size="271336" needRestart="true" />  
</updateFiles>


--------------update.config -----------------
<?xml version="1.0" encoding="utf-8"?>
<Config xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Enabled>true</Enabled>
  <ServerUrl>http://localhost:6666/updateService.xml</ServerUrl>
  <UpdateFileList>
    <LocalFile path="BLL.dll" lastver="1.0.0.0" size="4096" />
    <LocalFile path="DAL.exe" lastver="1.1.0.0" size="4096 " />
    <LocalFile path="Log.config" lastver="1.0.0.0" size="1227" />
    <LocalFile path="log4net.dll" lastver="1.0.0.0" size="270336" />
    <LocalFile path="UpgradeClient.exe" lastver="1.0.0.0" size="24576" />
  </UpdateFileList>
</Config>