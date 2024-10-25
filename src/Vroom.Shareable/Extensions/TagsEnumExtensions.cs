using Vroom.Shareable.Enums;

namespace Vroom.Shareable.Extensions;

public static class TagsEnumExtensions
{
    public static string GetTagName(this TagsEnum tagEnum)
    {
        return tagEnum switch
        {
            TagsEnum.Motos => "motos",
            TagsEnum.Entregadores => "entregadores",
            TagsEnum.Locacao => "locacao",
            _ => throw new ArgumentOutOfRangeException(nameof(tagEnum), tagEnum, null)
        };
    }
}