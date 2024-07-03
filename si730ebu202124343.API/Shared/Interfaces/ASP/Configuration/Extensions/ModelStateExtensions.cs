using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace si730ebu202124343.API.Shared.Interfaces.ASP.Configuration.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}