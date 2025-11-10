using WebAecCommon;
using System.Collections.Generic;

namespace WebAecRhino;

public static class Extensions
{
    public static CommonElement ToCommonElement(this Rhino.DocObjects.RhinoObject rhinoObject)
    {
        var properties = new Dictionary<string, string>();

        for (int i = 0; i < rhinoObject.Attributes.GetUserStrings().Count; i++)
        {
            var key = rhinoObject.Attributes.GetUserStrings().GetKey(i);
            if (key == null) continue;
            var value = rhinoObject.Attributes.GetUserString(key) ?? string.Empty;
            properties[key] = value;
        }

        return new CommonElement(rhinoObject.Id.ToString(), rhinoObject.Name, properties);
    }
}