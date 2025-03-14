# 自助签注机系统（反射加载案例ReflectionLoadingExample)

[![Avalonia](https://img.shields.io/badge/Avalonia-11.0-blue)](https://avaloniaui.net/)
[![.NET](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com/)

基于Avalonia框架开发的跨平台自助签注系统，实现出入境业务续签功能，支持模块化扩展和双屏交互操作。


> **法律声明**  
> 本项目的界面设计参考了网络公开报道的样式布局，所有代码实现均为原创。若涉及任何著作权问题，请通过邮箱 1541005676@qq.com 联系删除。

## 目录 📖
- [功能特性](#功能特性-)
- [系统架构](#系统架构-)

[//]: # (- [快速开始]&#40;#快速开始-&#41;)

[//]: # (  - [环境要求]&#40;#环境要求&#41;)

[//]: # (  - [安装指南]&#40;#安装指南&#41;)

[//]: # (  - [配置说明]&#40;#配置说明&#41;)

[//]: # (- [开发文档]&#40;#开发文档-&#41;)

[//]: # (  - [模块开发]&#40;#模块开发&#41;)

[//]: # (  - [双屏控制]&#40;#双屏控制&#41;)

[//]: # (- [贡献指南]&#40;#贡献指南-&#41;)

[//]: # (- [许可证]&#40;#许可证-&#41;)

## 功能特性 ✨

### 模块化系统
- **动态加载机制**  
  使用反射加载符合规范的业务module.dll
- **多屏协作,双屏控制**
- **配置驱动架构**  
  通过XML文件定义模块加载策略
  ```xml
  <!-- MoudlesConfig.xml -->
  <Root>
    <Module ModuleName="EntryExit" BusinessName="出入境业务" IsShow="true"/>
    <Module ModuleName="IDCard" BusinessName="身份证业务" IsShow="true"/>
    <Module ModuleName="TrafficPolice" BusinessName="交警业务" IsShow="true"/>
    <Module ModuleName="NoCriminalRecord" BusinessName="无犯罪证明记录" IsShow="true"/>
    <Module ModuleName="SocialSecurity" BusinessName="社保业务" IsShow="true"/>
    <Config ShowScreen="true" DefaultName="张三" DefaultSex="男"/>
  </Configuration>
  
