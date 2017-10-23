# Creating an MVC Project in VSCode

## Start MVC Project
```
dotnet new mvc
```

## Add Watcher Tools to a Project
1. Edit .csproj file to include:
```
<ItemGroup>
    <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
</ItemGroup> 
```
2. Run commands
```
dotnet restore
dotnet watch run 
```

## Add Logging Tools to a Project
1. Edit .csproj file to include:
```
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="2.0.0" />
</ItemGroup>
```
2. Add to Startup.cs
```
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
```
export ASPNETCORE_ENVIRONMENT=Development
```
__To production:*__
```
export ASPNETCORE_ENVIRONMENT=Production
```
_* Project default_

## Adding routes to a controller
__0. Change default routing in Startup.cs__
```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseMvc();
    }
```

__1. GET method__
```
[HttpGet]
[Route("index")]
public string Index(string Name)
{
    return Name;
}
```

__2. GET method returning JSON*__
```
[HttpGet]
[Route("")]
public JsonResult DisplayInt()
{
    return Json(24);
}
```
_* Json() Can return any object, even classes_

__3. GET method returning JSON with an anonymous object*__
```
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

  __4. POST method__
```
[HttpPost]
[Route("")]
public IACtionResult Other()
{
    // Return a view
}
```