using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vroom.Shareable.Enums;
using Vroom.Shareable.Extensions;

namespace Vroom.Api.Filter;

public class SwaggerTagsOrderFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Definindo a ordem das tags
        var orderedTags = Enum.GetValues(typeof(TagsEnum))
                              .Cast<TagsEnum>()
                              .Select(tagEnum => tagEnum.GetTagName())
                              .ToList();

        // Reordena as tags (essa parte é opcional se quiser ordenar também a lista de tags visível no Swagger)
        swaggerDoc.Tags = swaggerDoc.Tags
            .OrderBy(tag => orderedTags.IndexOf(tag.Name))
            .ToList();

        // Reordena os endpoints com base nas tags ordenadas
        var orderedPaths = swaggerDoc.Paths
            .OrderBy(pathItem =>
            {
                // Pega a primeira tag associada ao endpoint (supondo que cada endpoint tem apenas uma tag)
                var tag = pathItem.Value.Operations.First().Value.Tags.FirstOrDefault()?.Name;
                return orderedTags.IndexOf(tag);
            })
            .ToDictionary(item => item.Key, item => item.Value);

        // Substitui os endpoints na ordem desejada
        swaggerDoc.Paths = new OpenApiPaths();
        foreach (var path in orderedPaths)
        {
            swaggerDoc.Paths.Add(path.Key, path.Value);
        }
    }
}