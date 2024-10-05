using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Films.Core.Application.Utilities;

public class TypeBinder<T> : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var propertyName = bindingContext.ModelName;
        var value = bindingContext.ValueProvider.GetValue(propertyName);

        if (value == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        try
        {
            var deserializedValue = JsonConvert.DeserializeObject<T>(value.FirstValue);
            bindingContext.Result = ModelBindingResult.Success(deserializedValue);
        }
        catch 
        {
            bindingContext.ModelState
                .TryAddModelError(propertyName, "The value given is not the correct one.");
        }

        return Task.CompletedTask;
    }
}
