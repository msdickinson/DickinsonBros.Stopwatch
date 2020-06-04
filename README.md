# DickinsonBros.Stopwatch
<a href="https://www.nuget.org/packages/DickinsonBros.Stopwatch/">
    <img src="https://img.shields.io/nuget/v/DickinsonBros.Stopwatch">
</a>

A wrapper library for Stopwatch

Features
* Adds extensibility via abstraction
* Allows for unit testing

<a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_build?definitionScope=%5CDickinsonBros.Stopwatch">Builds</a>

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
