# Creating an MVC Project in VSCode

## Start MVC Project

```bash
dotnet new mvc
```

## Add Watcher Tools to a Project

__1. Edit .csproj file to include:__

```XML
<ItemGroup>
    <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
</ItemGroup>
```

__2. Run commands in terminal:__

```bash
dotnet restore
dotnet watch run
```

## Add Logging Tools to a Project

__1. Edit project.csproj file to include:__

```XML
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="2.0.0" />
</ItemGroup>
```

__2. Add to Startup.cs:__

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

## Submitting forms

- Make sure each form input field has a name
- Use the same name to pass values as parameter to controller method
- Names MUST match!

__1. Add within .CSHTML file:__

```HTML
<form action="method" method="post">
    <input type="text" name="TextField" />
    <input type="number" step="1" name="NumberField" />
    <button type="submit">Submit</button>
</form>
```

__2. Add to controller.cs file:__

```csharp
[HttpPost]
[Route("method")]
public IActionResult Method(string TextField, int NumberField)
{
    // Use form input values here
}
```

## Using ViewBag to send data to front-end

- ViewBag is a special dictionary that only persists over one view return (i.e. not through redirects)
- Must be set within the view method we want to send the data to

__1. Add to controller.cs file:__

```csharp
[HttpGet]
[Route("")]
public IActionResult Index()
{
    ViewBag.Example = "Hello World!";
    return View();
}
```

__2. Add to .CSHTML file:__

```csharp
<h1>@ViewBag.Example</h1>

// Alternatively can also declare & use inline:
@{
    string LocalString = ViewBag.Example + " Nice to see you!";
}
<h1>@LocalString</h1>
```

## Using Ajax/jQuery with JSON data

```javascript
$(document).ready(function(){
    // For an external request
    $.get("http://pokeapi.co/api/v2/pokemon/1", function(response){
        // Handle the response data
    });
    // For a back-end request
    $.get("/getusers", function(response){
        // Handle the response data
    });
});
```

## Redirecting to other controller methods

- Use the RedirectToAction() response method
- Pass another method within controller as a string parameter
    - e.g. RedirectToAction("OtherMethod)

```csharp
public class FirstController : Controller
{
    public IActionResult Method()
    {
        // Redirects to the "OtherMethod" method
        return RedirectToAction("OtherMethod")
    }

    public IActionResult OtherMethod()
    {
        return View();
    }
}
```

- Can also pass in additional parameters

```csharp
public class FirstController : Controller
{
    public IActionResult Method()
    {
        // Uses an anonymous object consisting of keys & values
        // Keys must match parameter names in the method that's being redirected
        return RedirectToAction("OtherMethod", new { Food = "sandwiches", Quantity = 5});
    }

    [HttpGet]
    [Route("other/{Food})"]
    public IActionResult OtherMethod(string Food, int Quantity)
    {
        Console.WriteLine($"I ate {Quantity} {Food}.");
        // Prints "I ate 5 sandwiches."
    }
}
```

- To redirect to another controller's method, must specify the controller name as well as the method name

```csharp
public class FirstController : Controller
{
    public IActionResult Method()
    {
        return RedirectToAction("Other Method", "Second");
        // "Second" refers to the SecondController class
    }
}

// Within another file
public class SecondController : Controller
{
    public IActionResult OtherMethod()
    {
        return View();
    }
}
```

## Session

- Can only use Session to hold onto integers & strings by default
- To store a string in session, use ".SetString" (first string is key, second is value to retrieve)
    - To retrieve a string from session, use ".GetString"
- To store an int, use ".SetInt32"
    - To retrieve an int, use ".GetInt32"

__1. Add to Startup.cs:__

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSession();
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    ...
    app.UseSession();
}
```

__2. Add to controller.cs file:*__

```csharp
using Microsoft.AspNetCore.Http;
...

// Set session variable
HttpContext.Session.SetString("UserName", "Samantha");

// Retrieve session variable
string LocalVariable = HttpContext.Session.GetString("UserName");

// Store an int in session
string LocalVariable = HttpContext.Session.GetString("UserName", 28);

// Retrieve an int in session
int? IntVariable = HttpContext.Session.GetInt32("UserAge");
```

_*Must use int? instead of int because int? is nullable._

- Clear session using the Clear() method

```csharp
HttpContext.Session.Clear();
```

## Using Session to Serialize Objects as JSON Strings

- Can call SetObjectAsJson just like other session set methods by passing a key and a value
- Use the following code somewhere in your namespace, outside other classes

```csharp
using Newtonsoft.Json;

public static class SessionExtensions
{
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        // Helper function to serialize the object to JSON and store it as a string in session
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    // Generic type T is a stand-in indicating need to specify the type on retrieval
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        string value = session.GetString(key);
        // When retrieving, the object is deserialized based on type specified
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
```

__Use inside a controller method:__

```csharp
List<object> NewList = new List<object>();

HttpContext.Session.SetObjectAsJson("The List", NewList);

// Specify List type for retrieval
List<object> Retrieve = HttpContext.Session.GetObjectFromJson<List<object>>("TheList");
```

## Using TempData to Persist Data with Redirect

- Used to pass more complex data from one method to another when redirecting
- TempData is like a temporary session that only persists across one redirect
- Built ontop of session, therefore cannot be used without enabling a session

```csharp
using Microsoft.AspNetCore.Http;

...
public IActionResult Method()
{
    TempData["Variable"] = "Hello World";
    return RedirectToAction("OtherMethod");
}

public IActionResult OtherMethod()
{
    Console.WriteLine(TempData["Variable"]);
    // Prints "Hello World" when redirected to from Method()
}
```
