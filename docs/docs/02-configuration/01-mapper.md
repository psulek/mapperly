# Mapper configuration

The `MapperAttribute` provides options to customize the generated mapper class.

## Copy behaviour

By default, Mapperly does not create deep copies of objects to improve performance.
If an object can be directly assigned to the target, it will do so
(eg. if the source and target type are both `Car[]`, the array and its entries will not be cloned).
To create deep copies, set the `UseDeepCloning` property on the `MapperAttribute` to `true`.

```csharp
// highlight-start
[Mapper(UseDeepCloning = true)]
// highlight-end
public partial class CarMapper
{
  ...
}
```

## Properties

On each mapping method declaration, property mappings can be customized.
If a property on the target has a different name than on the source, the `MapPropertyAttribute` can be applied.
If a property should be ignored, the `MapperIgnoreTargetAttribute` or `MapperIgnoreSourceAttribute` can be used.

```csharp
[Mapper]
public partial class CarMapper
{
    // highlight-start
    [MapProperty(nameof(Car.Model), nameof(CarDto.ModelName))]
    [MapperIgnoreTarget(nameof(CarDto.MakeId))]
    [MapperIgnoreSource(nameof(Car.Id))]
    // highlight-end
    public partial CarDto ToDto(Car car);
}
```

## Property name mapping strategy

By default, property names are matched using a case sensitive strategy. If all properties differ only in casing, for example ModelName on the source and modelName on the target, the `[MapperAttribute]` can be used with the `PropertyNameMappingStrategy` option.

```csharp
// highlight-start
[Mapper(PropertyNameMappingStrategy = PropertyNameMappingStrategy.CaseInsensitive)]
// highlight-end
public partial class CarMapper
{
    public partial CarDto ToDto(Car car);
}

public class Car
{
    public string ModelName { get; set; }
}

public class CarDto
{
    public string modelName { get; set; }
}
```