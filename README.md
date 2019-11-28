# WestcnSdk

## Qc.WestcnSdk

`Qc.WestcnSdk` 是一个基于 `.NET Standard 2.0` 构建，对西部数码代理平台的常用接口进行了封装。


### 使用 WestcnSdk


#### 一.安装程序包

[![Nuget](https://img.shields.io/nuget/v/Qc.WestcnSdk)](https://www.nuget.org/packages/Qc.WestcnSdk/)

- dotnet cli  
  `dotnet add package Qc.WestcnSdk`
- 包管理器  
  `Install-Package Install-Package Qc.WestcnSdk`

#### 二.添加配置

> 如需实现自定义动态获取应用配置，可自行实现接口 `IWestcnSdkHook`  
> 默认提供 `DefaultWestcnSdkHook`，从 `appsettings.json` 获取配置信息

```cs
using WestcnSdk;
public void ConfigureServices(IServiceCollection services)
{
  //...
  services.AddWestcnSdk<WestcnSdk.DefaultWestcnSdkHook>(opt =>
  {
       opt.ApiUrl = "http://api.west263.com/";
       opt.DomainApiUrl= "https://api.west.cn/";
       opt.UserId = "test";
       opt.ApiPwd = "test123";
  });
  //...
}
```

#### 三.代码中使用

在需要地方注入`WestcnService`后即可使用

### WestcnConfig 配置项

Westcn文档地址: 

## 示例说明

`Qc.WestcnSdk.Sample` 为示例项目，可进行测试
