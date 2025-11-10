using WebAecCommon;

namespace WebAecRevit;

public static class Extensions
{
    public static CommonElement ToCommonElement(this Element revitElement)
    {
        var properties = new Dictionary<string, string>();

        foreach (var item in revitElement.GetOrderedParameters())
        {
            properties[item.Definition.Name] = item.AsValueString();
        }

        return new CommonElement(revitElement.Id.ToString(), revitElement.Name, properties);
    }
}