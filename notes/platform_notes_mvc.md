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
To Development
```
export ASPNETCORE_ENVIRONMENT=Development
```
To Production (back to default)
```
export ASPNETCORE_ENVIRONMENT=Production
```
