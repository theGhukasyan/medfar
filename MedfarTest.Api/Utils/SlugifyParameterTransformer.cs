using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace MedfarTest.Api.Utils;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null)
        {
            return null;
        }

        var pattern = @"([A-Z][a-z]+)";
        var output = Regex.Replace(value.ToString(), pattern, "-$1").TrimStart('-').ToLower();

        return output;
    }
}