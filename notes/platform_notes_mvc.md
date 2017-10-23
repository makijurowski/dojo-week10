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

## Change work environment for testing (MacOS/Linux)
To development:
```
export ASPNETCORE_ENVIRONMENT=Development
```
To production:*
```
export ASPNETCORE_ENVIRONMENT=Production
```
_* Project default_

## Adding routes to a controller
GET method
```
[HttpGet]
[Route("index")]
public string Index(string Name)
{
    return Name;
}
```

GET method returning JSON*
```
[HttpGet]
[Route("")]
public JsonResult DisplayInt()
{
    return Json(24)
}
```
_* Json() Can return any object, even classes_

  
POST method
```
[HttpPost]
[Route("")]
public IACtionResult Other()
{
    // Return a view
}
```

GET method returning JSON with an anonymous object*
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