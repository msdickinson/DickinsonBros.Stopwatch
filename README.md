# DickinsonBros.Stopwatch
<a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=31&amp;branchName=master"> <img alt="Azure DevOps builds (branch)" src="https://img.shields.io/azure-devops/build/marksamdickinson/DickinsonBros/31/master"> </a> <a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=31&amp;branchName=master"> <img alt="Azure DevOps coverage (branch)" src="https://img.shields.io/azure-devops/coverage/marksamdickinson/dickinsonbros/31/master"> </a><a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_release?_a=releases&view=mine&definitionId=15"> <img alt="Azure DevOps releases" src="https://img.shields.io/azure-devops/release/marksamdickinson/b5a46403-83bb-4d18-987f-81b0483ef43e/15/16"> </a><a href="https://www.nuget.org/packages/DickinsonBros.Stopwatch/"><img src="https://img.shields.io/nuget/v/DickinsonBros.Stopwatch"></a>

A wrapper library for Stopwatch

Features
* Adds extensibility via abstraction
* Allows for unit testing

<h2>Example Usage</h2>

```C#

Console.WriteLine("Start Timer And Wait 1 Seconds");
stopwatchService.Start();
await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

```

    Start Timer And Wait 1 Seconds
    ElapsedMilliseconds: 1008

Example Runner Included in folder "DickinsonBros.Stopwatch.Runner"

<h2>Setup</h2>

<h3>Add Nuget References</h3>

    https://www.nuget.org/packages/DickinsonBros.Stopwatch/
    https://www.nuget.org/packages/DickinsonBros.Stopwatch.Abstractions

<h3>Create Instance</h3>

```C#    
var stopwatchService = new StopwatchService()
```

<h3>Create Instance (With Dependency Injection)</h3>

```C#        

var services = new ServiceCollection();   

//Add Service
serviceCollection.AddStopwatchService();

//Build Service Provider 
using (var provider = services.BuildServiceProvider())
{
   var dateTimeService = provider.GetRequiredService<IStopwatchService>();
}
```    
