# Models & Validation

## Model Classes
- Manages information for us
- Consists of __information__ & validation for __fields__
- Unlike Django, no set model manager, but can use dbConnector within models to use as a manager
- Otherwise rely on services/factory?
- Without ORM, must use raw SQL and lists of data
- No constructor necessary, just definitions for fields


## Using Validations

```csharp
public class TestModel
{
    [Required]    // Data annotation
    public string name { get; set; }
}
```

- Controller receives a post request & tracks the model state
- Model state: validity and current state of key/value pairs

```csharp
Try Validate Model(test = TestModel)
{
    // Must pass in TestModel as an instance
}

test.IsValid // Returns true or false, if true add to db
```
_* Only works for data that is annotated_

```chsarp
@ViewBag.Errors 
```