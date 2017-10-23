# ASP.NET Part 1

## Returning a view in a controller

```csharp
public IActionResult Index()
{
    return View;
}
```

## .CSHTML

- Stands for C# + HTML
- Rendered by razor

```csharp
@ {
    ...
}
```

## POST Data

- Make sure variable names match

- Within CSHTML:

```HTML
<form>
    <input name="bob" type="text">
</form>
```

- Within view:

```csharp
[HttpPost]
[Route('Process')]
{
    public IActionResult FormHandler(string bob)
}
```

## ViewBag (View Data Wrapper)

- Equivalent to context
- Can access things within ViewBag in Razor template
- ONLY lasts one request cycle & then is refreshed
- Use session to get ViewBag via TempData
    - TempData is setup to wipe data within one request
    - TempData is combo of ViewBag & session
    - Allows data to persist through a redirect
- ViewBag & TempData are dictionaries
- Session can only handle basic value types (e.g. strings & integers)
