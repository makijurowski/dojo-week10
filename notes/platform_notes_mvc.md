# Creating an MVC Project in VSCode

## Start MVC Project

```bash
dotnet new mvc
```

## Add Watcher Tools to a Project

1. Edit .csproj file to include:

```XML
<ItemGroup>
    <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
</ItemGroup>
```

2. Run commands

```bash
dotnet restore
dotnet watch run
```

## Add Logging Tools to a Project

1. Edit .csproj file to include:

```XML
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="2.0.0" />
</ItemGroup>
```

2. Add to Startup.cs

```csharp
using Microsoft.Extensions.Logging
...
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        ...
        loggerFactory.AddConsole();
    }
```

## Change work environment for testing (MacOS/Linux)

__To development:__

```bash
export ASPNETCORE_ENVIRONMENT=Development
```

__To production:*__

```bash
export ASPNETCORE_ENVIRONMENT=Production
```

_* Project default_

## Adding routes to a controller

__1. Change default routing in Startup.cs__

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseMvc();
    }
```

__2. GET method__

```csharp
[HttpGet]
[Route("index")]
public string Index(string Name)
{
    return Name;
}
```

__3. GET method returning JSON*__

```csharp
[HttpGet]
[Route("")]
public JsonResult DisplayInt()
{
    return Json(24);
}
```

_* Json() Can return any object, even classes_

__4. GET method returning JSON with an anonymous object*__

```csharp
[HttpGet]
[Route("displayint")]
public JsonResult DisplayInt()
{
    var AnonObject = new {
        FirstName = "Maki",
        LastName = "Roggers",
        Age = 10
    }
    return Json(AnonObject);
}
```

_* Used to return values of varying types_

  __5. POST method__

```csharp
[HttpPost]
[Route("")]
public IACtionResult Other()
{
    // Return a view
}
```

## Linking views to a controller

__1. Make a subfolder within views that matches the name of your controller.__

- E.g. UsersController -> "Users" directory within "Views" directory
- If a view is to be shared by multiple controllers, add to the "Shared" directory.

__2. Add method to controller.__

```csharp
[HttpGet]
[Route("")]
public IActionResult Index()
{
    return View();
    // or return View("Index");
    // Both will render the same view (only use one!)
}
```

## Add C# Code to .CSHTML (Razor View Engine)

__Examples:*__

```csharp
<body>
    @{
        var StringList = new List<string>{
                                "one",
                                "two",
                                "three",
                                "four"
                            };

        foreach(var word in StringList)
        {
            <div>
                <p>@word</p>
                @if(word.Length < 4)
                {
                    <p>@word is a short word</p>
                }
            </div>
        }
    }
</body>
```

_*Must use @ symbol in front of "word" to use as a variable_