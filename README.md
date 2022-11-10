# Question Box

一个基于 Blazor 的简易（<del>和README一样简陋</del>）匿名提问箱。

默认采用单用户模式，理论上可以开启多用户模式但需要较多调整（简而言之，懒。<del>还有可能有审核风险</del>）



## 自行编译

需要安装 .NET 7 和 nodejs

由于使用了 tailwindcss, 编译之前需要跑一下npm.

```bash
# 第一次使用项目
npm install
# 每次编译前
npm run buildcss
```

