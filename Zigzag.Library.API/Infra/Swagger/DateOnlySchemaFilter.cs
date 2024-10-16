using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Zigzag.Library.API.Infra.Swagger;

public class DateOnlySchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(DateTime))
        {
            schema.Type = "string";
            schema.Format = "date";
            schema.Example = new OpenApiString("2024-10-15");
        }
    }
}